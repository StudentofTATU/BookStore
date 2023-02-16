using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public int Like { get; set; }
        public decimal Cost { get; set; }

        [ForeignKey("Category")]
        public Category CategoryId { get; set; }

        public ICollection<KeyWord> Keywords { get; set; }
        public ICollection<Book> SimilarBooks { get; set; }

    }
}
