namespace emedicineBE.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string OrderNo { get; set; } = string.Empty;
        public decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; } = string.Empty; 

    }
}
