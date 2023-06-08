namespace SqlTableDependencyPractice
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            btnStop = new Button();
            txtConsole = new TextBox();
            btnClear = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(29, 37);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(131, 56);
            btnStart.TabIndex = 0;
            btnStart.Text = "启动监听";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(210, 37);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(131, 56);
            btnStop.TabIndex = 1;
            btnStop.Text = "停止监听";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtConsole
            // 
            txtConsole.BackColor = SystemColors.Window;
            txtConsole.Location = new Point(29, 110);
            txtConsole.Multiline = true;
            txtConsole.Name = "txtConsole";
            txtConsole.ReadOnly = true;
            txtConsole.ScrollBars = ScrollBars.Vertical;
            txtConsole.Size = new Size(984, 468);
            txtConsole.TabIndex = 3;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(391, 37);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(131, 56);
            btnClear.TabIndex = 2;
            btnClear.Text = "清空输出";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 601);
            Controls.Add(btnClear);
            Controls.Add(txtConsole);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Font = new Font("Arial", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SqlTableDependencyPractice";
            TopMost = true;
            FormClosed += FormMain_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private TextBox txtConsole;
        private Button btnClear;
    }
}