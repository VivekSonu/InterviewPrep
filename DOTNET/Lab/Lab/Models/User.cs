using System.ComponentModel.DataAnnotations;

namespace Lab.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Age { get; set; }

        public string PasswordHash { get; set; }
        public string Role { get; set; } = "User";


        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }


        public List<Order> Orders { get; set; }
    }
}
