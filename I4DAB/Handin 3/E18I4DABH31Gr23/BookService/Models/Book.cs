using System.ComponentModel.DataAnnotations;

namespace BookService.Models
{
    /// <summary>
    /// Book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// BookId
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// BookTitle
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// BookYear
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// BookPrice
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// BookGenre
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Foreign Key
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// Navigation Property
        /// </summary>
        public Author Author { get; set; }
    }
}