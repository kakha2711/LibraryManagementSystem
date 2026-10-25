
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.Entitys
{
    public class Library
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        public List<Book> Books { get; set; }
    }
}
