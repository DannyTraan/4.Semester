using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookService.Models
{
    /// <summary>
    /// Author
    /// </summary>
    public class Author
    {
        /// <summary>
        /// AuthorId
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Author Name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}