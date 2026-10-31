
using LibraryManagementSystem.Interface.IRepository;
using LibraryManagementSystem.Models.DTOs;
using LibraryManagementSystem.Models.Entitys;

namespace LibraryManagementSystem.Service
{
    public class LibreryService
    {
        private readonly ILibraryRepository _libraryRepository;
        public LibreryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public Task<List<LibraryDTO>> GetAllLibreryAsync()
        {
            var library = _libraryRepository.GetAllLibreryAsync().Result;

            List<LibraryDTO> libraryDTOs = new List<LibraryDTO>();

            foreach (var item in library)
            {
                libraryDTOs.Add(new LibraryDTO
                {
                    Name = item.Name,
                    Address = item.Address
                });
            }

            return Task.FromResult(libraryDTOs);
        }

        public Task<LibraryDTO> GetLibreryByIdAsync(int id)
        {
            var library = _libraryRepository.GetLibreryByIdAsync(id).Result;

            LibraryDTO libraryDTO = new LibraryDTO
            {
                Name = library.Name,
                Address = library.Address
            };
            return Task.FromResult(libraryDTO);
        }

        public Task<string> CreateLibreryAsync(LibraryDTO libraryDTO)
        {
            var existingLibrary = _libraryRepository.GetAllLibreryAsync().Result.All(l => l.Name != libraryDTO.Name);

            var existingLibrary0 = _libraryRepository.GetAllLibreryAsync().Result.FindAll(l => l.Name == libraryDTO.Name);

            var createdLibrary = "";

            if (!existingLibrary)
            {
                 createdLibrary = $"Library with name '{libraryDTO.Name}' ამ სახელით უკვე დამატებულია.";
                return Task.FromResult(createdLibrary);
            }

            //Task.FromResult($"Library with name '{libraryDTO.Name}' already exists.")

            Library createdLibraryDTO = new Library
            {
                Name = libraryDTO.Name,
                Address = libraryDTO.Address
            };


            createdLibrary = _libraryRepository.AddLibreryAsync(createdLibraryDTO).Result;

            //Console.WriteLine($"createdLibrary: {createdLibrary}");

            return Task.FromResult(createdLibrary);
        }

        public Task<string> UpdateLibreryAsync(int id, LibraryDTO libraryDTO)
        {
            Library library = new Library
            {
                Id = id,
                Name = libraryDTO.Name,
                Address = libraryDTO.Address
            };

            var updatedLibrary = _libraryRepository.UpdateLibreryAsync(library, id).Result;
            
            Console.WriteLine($"updatedLibrary: {updatedLibrary}");

            return Task.FromResult(updatedLibrary);
        }

        public Task<string> DeleteLibreryAsync(int id)
        {
            var deletedLibrary = _libraryRepository.DeleteLibreryAsync(id).Result;

            Console.WriteLine($"deletedLibrary: {deletedLibrary}");
            return Task.FromResult(deletedLibrary);
        }
    }
}
