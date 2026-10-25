
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.DTOs
{
    public class BookDetailsDTO
    {
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public int PublishedYear { get; set; }
    }
}
