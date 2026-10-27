
using LibraryManagementSystem.Models.Entitys;

namespace LibraryManagementSystem.Interface.IService
{
    public interface ILibraryService
    {
        Task<List<Library>> GetAllLibreryAsync();
        Task<Library> GetLibreryByIdAsync(int id);
        Task<String> AddLibreryAsync(Library library);
        Task<String> UpdateLibreryAsync(Library library);
        Task<String> DeleteLibreryAsync(int id);
    }
}
