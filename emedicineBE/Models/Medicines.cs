namespace emedicineBE.Models
{
    public class Medicines
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpDate { get; set; }
        public string ImageUrl { get; set; } = string.Empty;        
        public int Status { get; set; }
        public string Type { get; set; } = string.Empty;                
    }
}
