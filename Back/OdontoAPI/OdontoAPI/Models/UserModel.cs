using System.ComponentModel.DataAnnotations;

namespace OdontoAPI.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public string? Password { get; set; }
        public string[] Roles { get; set; }
    }
        
}