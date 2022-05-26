using System.ComponentModel.DataAnnotations;

namespace EShop.Models.User
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Adress { get; set; } = null!;

        [Required]
        public int Number { get; set; }

        [Required]
        private byte[] PHash { get; set; } = null!;

        [Required]
        private byte[] PSalt { get; set; } = null!;
    }
}
