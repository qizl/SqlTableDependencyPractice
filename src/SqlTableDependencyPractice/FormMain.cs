using Newtonsoft.Json;
using SqlTableDependencyPractice.Models;
using System.Configuration;
using System.Linq.Expressions;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.Abstracts;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Where;

#pragma warning disable CS8602 // 解引用可能出现空引用。

namespace SqlTableDependencyPractice
{
    public partial class FormMain : Form
    {
        private SqlTableDependency<Product> _sqlTableDependency;

        public FormMain()
        {
            InitializeComponent();

            this.initialize();
        }

        private void initialize()
        {
            // The mapper object is used to map model properties 
            // that do not have a corresponding table column name.
            // In case all properties of your model have same name 
            // of table columns, you can avoid to use the mapper.
            var mapper = new ModelToTableMapper<Product>();
            mapper.AddMapping(c => c.ExpireDateTime, "ExpireDate");
            mapper.AddMapping(c => c.ExpireDateTimeNullable, "ExpireDateNullable");

            // Define WHERE filter
            Expression<Func<Product, bool>> expression = p => (p.CategoryId == (int)CategorysEnum.Food || p.CategoryId == (int)CategorysEnum.Drink) && p.Price < 100;
            ITableDependencyFilter whereCondition = new SqlTableDependencyFilter<Product>(expression, mapper);

            // As table name (Products) does not match model name (Product), its definition is needed.
            var connectionString = ConfigurationManager.ConnectionStrings["SqlServerTestDb"].ConnectionString;
            this._sqlTableDependency = new SqlTableDependency<Product>(connectionString, "Products", mapper: mapper, includeOldValues: true, filter: whereCondition);

            this._sqlTableDependency.OnChanged += Dep_OnChanged;
            this._sqlTableDependency.OnError += Dep_OnError;
            this._sqlTableDependency.OnStatusChanged += Dep_OnStatusChanged;
        }

        private void start()
        {
            this._sqlTableDependency.Start();
        }

        private void stop()
        {
            this._sqlTableDependency.Stop();
            this._sqlTableDependency.Dispose();
        }

        private void Dep_OnStatusChanged(object sender, TableDependency.SqlClient.Base.EventArgs.StatusChangedEventArgs e)
        {
            this.appendText($"SqlTableDependency Status = {e.Status}");
        }

        private void Dep_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            this.appendText(e.Message);
            this.appendText(e.Error?.Message);
        }

        private void Dep_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Product> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                this.appendText($"ChangeType：{e.ChangeType}");
                this.appendText($"Entity：{JsonConvert.SerializeObject(e.Entity)}");
            }

            if (e.ChangeType == ChangeType.Update && e.EntityOldValues != null)
            {
                this.appendText($"EntityOldValues：{JsonConvert.SerializeObject(e.EntityOldValues)}");
            }
        }

        private void appendText(string text)
        {
            this.Invoke(() =>
            {
                this.txtConsole.AppendText(text);
                this.txtConsole.AppendText(Environment.NewLine);

                this.txtConsole.SelectionStart = this.txtConsole.Text.Length;
                this.txtConsole.SelectionLength = 0;
                this.txtConsole.Focus();
            });
        }

        #region Events - Forms
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.stop();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtConsole.ResetText();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.stop();

            Environment.Exit(0);
        }
        #endregion
    }
}