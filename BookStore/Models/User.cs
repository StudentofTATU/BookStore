using System.ComponentModel.DataAnnotations;
using BookStore.Data.Enums;

namespace BookStore.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}
