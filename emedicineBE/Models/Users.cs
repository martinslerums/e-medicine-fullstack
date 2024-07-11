namespace emedicineBE.Models
{
    public class Users   
    {   
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Fund { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string OrderType { get; set; } = string.Empty;
    }
}
