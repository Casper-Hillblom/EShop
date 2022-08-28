namespace EShop.Models.Order
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; } = null!;
        
        public string UserEmail { get; set; } = null!; 

    }
}
