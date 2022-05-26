namespace EShop.Models.User
{
    public class UserRequest
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public int Number { get; set; }

        public string? Password { get; set; } = null!; //Använda detta på något sätt
    }
}
