using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class KeyWord
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
