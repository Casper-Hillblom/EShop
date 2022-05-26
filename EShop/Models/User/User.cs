namespace EShop.Models.User
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public int Number { get; set; }
    }
}
