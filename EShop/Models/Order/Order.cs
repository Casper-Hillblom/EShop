namespace EShop.Models.Order
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; } = null!;
        
        public string UserEmail { get; set; } = null!; //För att veta vem som lägger beställningen

        public string[] Products { get; set; } = null!; //Produktnamnet

        public int[] Amount { get; set; } = null!; //Antal per produkt
    }
}
