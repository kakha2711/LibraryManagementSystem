
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models.Entitys
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(150)]
        public string Author { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public double Price { get; set; }


        public int LibraryId { get; set; }
        public Library Library { get; set; }

       
        //public int BookDetailsId { get; set; }
        public BookDetails BookDetails { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
