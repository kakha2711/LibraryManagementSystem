
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models.Entitys
{
    public class BookDetails
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string ISBN { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Page count must be a positive integer.")]
        public int PageCount { get; set; }
        [Required]
        [Range(-1000, 2023, ErrorMessage = "Published year must be between 1000 and 2023.")]
        public int PublishedYear { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
