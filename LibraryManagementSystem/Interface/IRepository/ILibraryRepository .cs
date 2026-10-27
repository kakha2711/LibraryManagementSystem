
using LibraryManagementSystem.Models.Entitys;

namespace LibraryManagementSystem.Interface.IRepository
{
    public interface ILibraryRepository
    {

        Task<List<Library>> GetAllLibreryAsync();
        Task<Library> GetLibreryByIdAsync(int id);
        Task<String> AddLibreryAsync(Library library);
        Task<String> UpdateLibreryAsync(Library library);
        Task<String> DeleteLibreryAsync(int id);

    }
}

