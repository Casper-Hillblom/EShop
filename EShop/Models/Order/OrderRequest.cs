namespace EShop.Models.Order
{
    public class OrderRequest
    {
        public string Status { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public string[] Products { get; set; } = null!; //Produktnamnet

        public int[] Amount { get; set; } = null!; //Antal per produkt
    }
}
