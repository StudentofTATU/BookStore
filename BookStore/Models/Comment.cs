using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

        [ForeignKey("User")]
        public int AuthorId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

    }
}
