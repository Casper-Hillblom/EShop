using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

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
        public string Password { get; set; } = null!;

        //[Required]
        //public byte[] PHash { get; private set; } = null!;

        //[Required]
        //public byte[] PSalt { get; private set; } = null!;

        //public void CreateSecurePassword(string password)
        //{
        //    using var key = new HMACSHA512();
        //    PSalt = key.Key;
        //    PHash = key.ComputeHash(Encoding.UTF8.GetBytes(password));
        //    key.Clear();
        //}

        //public bool CheckPassword(string password)
        //{
        //    using (var key = new HMACSHA512(PSalt))
        //    {
        //        var hash = key.ComputeHash(Encoding.UTF8.GetBytes(password));

        //        for (int i = 0; i < hash.Length; i++)
        //        {
        //            if (hash[i] != PHash[i])
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}
    }
}
