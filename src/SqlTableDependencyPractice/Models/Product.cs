namespace SqlTableDependencyPractice.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int? IdNullable { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }
        public decimal? PriceNullable { get; set; }

        public float ExcangeRate { get; set; }
        public float? ExcangeRateNullable { get; set; }

        public DateTime ExpireDateTime { get; set; }
        public DateTime ExpireDateTimeNullable { get; set; }

        public int CategoryId { get; set; }
    }
}
