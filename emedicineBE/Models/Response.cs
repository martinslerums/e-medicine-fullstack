namespace emedicineBE.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; } = string.Empty;

        public List<Users> listUsers { get; set; } = new List<Users>();
        public Users user { get; set; } = new Users();

        public List<Medicines> listMedicines { get; set; } = new List<Medicines>();
        public Medicines medicine { get; set; } = new Medicines();

        public List<Cart> listCart { get; set; } = new List<Cart>();

        public List<Orders> listOrders { get; set; } = new List<Orders>();
        public Orders order { get; set; } = new Orders();

        public List<OrderItems> listItems { get; set; } = new List<OrderItems>();
        public OrderItems orderItems { get; set; } = new OrderItems();
    }

}
