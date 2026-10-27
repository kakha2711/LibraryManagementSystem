
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interface.IRepository;
using LibraryManagementSystem.Models.Entitys;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LibraryManagementSystem.Repository
{
    internal class LibraryRepository : ILibraryRepository
    {

        private readonly LibraryManagementSystemDbContext _context;

        public LibraryRepository(LibraryManagementSystemDbContext context)
        {
            _context = context;
        }



        public Task<List<Library>> GetAllLibreryAsync()
        {
            ICollection<Library> libraries = new List<Library>();

            const string query = "SELECT * FROM Library";

            using var connection = new SqlConnection(_context.ConnectionString);
            using var command = new SqlCommand(query, connection);
             
            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                if(reader.HasRows)
                {
                    var library = new Library
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2)
                    };
                    libraries.Add(library);
                }
            }

            return Task.FromResult(libraries.ToList());

        }

        public Task<Library> GetLibreryByIdAsync(int id)
        {
            Library library = new Library();

            const string query = "SELECT * FROM Library WHERE Id = @Id";

            using var connection = new SqlConnection(_context.ConnectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);
            connection.Open();

            using var reader = command.ExecuteReader();

           
                if (reader.HasRows)
                {
                     library = new Library
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2)
                    };
                    
                }
            

            return Task.FromResult(library);

        }

        public Task<string> AddLibreryAsync(Library library)
        {
            List<Library> getAllLibreryOld = GetAllLibreryAsync().Result;

            const string query = "INSERT INTO Library (Name, Address) VALUES (@Name, @Address)";

            using var connection = new SqlConnection(_context.ConnectionString);
            using var command = new SqlCommand(query, connection);

            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@Name", library.Name);
            command.Parameters.AddWithValue("@Address", library.Address);

            connection.Open();
            command.ExecuteNonQuery();

            List<Library> getAllLibrerynew = GetAllLibreryAsync().Result;

            string message = getAllLibrerynew.Count > getAllLibreryOld.Count ? "Library added successfully." : "Failed to add library.";

            return Task.FromResult(message);
        }

        public Task<string> UpdateLibreryAsync(Library library)
        {
            List<Library> getAllLibreryOld = GetAllLibreryAsync().Result;

            const string query = "UPDATE Library SET Name = @Name, Address = @Address WHERE Id = @Id";

            using var connection = new SqlConnection(_context.ConnectionString);
            using var command = new SqlCommand(query, connection);

            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@Id", library.Id);
            command.Parameters.AddWithValue("@Name", library.Name);
            command.Parameters.AddWithValue("@Address", library.Address);

            connection.Open();
            command.ExecuteNonQuery();

            List<Library> getAllLibreryNew = GetAllLibreryAsync().Result;
            string message = getAllLibreryNew.Count > getAllLibreryOld.Count ? "Library updated successfully." : "Failed to update library.";

            return Task.FromResult(message);
        }

        public Task<string> DeleteLibreryAsync(int id)
        {
            List<Library> getAllLibreryOld = GetAllLibreryAsync().Result;

            const string query = "DELETE FROM Library WHERE Id = @Id";

            using var connection = new SqlConnection(_context.ConnectionString);
            using var command = new SqlCommand(query, connection);

            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            command.ExecuteNonQuery();

            List<Library> getAllLibreryNew = GetAllLibreryAsync().Result;
            string message = getAllLibreryNew.Count < getAllLibreryOld.Count ? "Library deleted successfully." : "Failed to delete library.";

            return Task.FromResult(message);
        }
    }
}
