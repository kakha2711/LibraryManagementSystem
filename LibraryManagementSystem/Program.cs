using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models.DTOs;
using LibraryManagementSystem.Models.Entitys;
using LibraryManagementSystem.Service;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;


            LibraryManagementSystemDbContext context = new LibraryManagementSystemDbContext();

            LibreryService libreryService = new LibreryService(new Repository.LibraryRepository(context));


            //========================================add library========================
            Console.WriteLine("ბიბლიოთეკის მართვის სისტემა");
            Console.Write("ბიბლიოთეკის სახელი: ");
            string libraryName = Console.ReadLine();

            Console.Write("ბიბლიოთეკის მისამართი: ");
            string libraryAddress = Console.ReadLine();

            var library =libreryService.CreateLibreryAsync(new LibraryDTO
            {
                Name = libraryName,
                Address = libraryAddress
            }).Result;

            Console.WriteLine(library);

            //========================end add library========================

            //========================================get all library========================

            //libreryService.GetAllLibreryAsync().Result.ForEach(library =>
            //{
            //    Console.WriteLine($"ბიბლიოთეკის სახელი: {library.Name},\n მისამართი: {library.Address}");
            //});

            //========================end get all library========================

            //========================================get library by id========================

            //LibraryDTO librery = libreryService.GetLibreryByIdAsync(2).Result;

            //Console.WriteLine($" ბიბლიოთეკის სახელი: {librery.Name},\n მისამართი: {librery.Address}");

            //========================end get library by id========================

            //========================================Update library========================

            //libreryService.UpdateLibreryAsync(2, new LibraryDTO
            //{
            //    Name = "Updated Library Name",
            //    Address = "Updated Library Address"
            //}).Wait();

            //libreryService.UpdateLibreryAsync(2, new LibraryDTO
            //{
            //    Name = "ფოთის მთავარი ბიბლიოთეკა",
            //    Address = "ზუგდიდის ქ. 44"
            //}).Wait();

            //========================end Update library========================

            //========================================Delete library========================

            //libreryService.DeleteLibreryAsync(5).Wait();

            //========================end Delete library========================

            #region OuldVersion
            //========================================add library========================
            //Console.Write("ბიბლიოთეკის სახელი: ");
            //var libraryName = Console.ReadLine();

            //Console.Write("ბიბლიოთეკის მისამართი: ");
            //var libraryAddress = Console.ReadLine();

            //Library libraries = new Library
            //{
            //    Name = libraryName,
            //    Address = libraryAddress
            //};


            //context.Librarie.AddRange(libraries);
            //context.SaveChanges();

            //========================end library========================


            //========================================add book to library========================

            // List<Library> libreryList = context.Librarie.ToList();

            // var libreryName = AnsiConsole.Prompt(
            // new SelectionPrompt<string>()
            //.Title("Select a city")
            //.PageSize(5)
            //.MoreChoicesText("[grey](Use arrow keys to see more cities)[/]")
            //.AddChoices(libreryList.Select(l => l.Name)));

            // AnsiConsole.MarkupLine($"You selected: [blue]{libreryName}[/]");


            // int selectedLibraryId = libreryList.FirstOrDefault(l => l.Name == libreryName)?.Id ?? 0;

            // Console.Write("წიგნის სათაური: ");
            // var bookTitle = Console.ReadLine();

            // Console.Write("წიგნის ავტორი: ");
            // var bookAuthor = Console.ReadLine();

            // Console.Write("წიგნის ფასი: ");
            // var bookPriceInput = Console.ReadLine();
            // if (!double.TryParse(bookPriceInput, out var bookPrice))
            // {
            //     AnsiConsole.MarkupLine($"[red]Invalid price format.[/]");
            //     return;
            // }

            // Book book = new Book
            // {
            //     Title = bookTitle,
            //     Author = bookAuthor,
            //     Price = bookPrice,
            //     LibraryId = selectedLibraryId
            // };


            // context.Book.AddRange(book);
            // context.SaveChanges();

            //========================end book to library========================


            //========================================add bookDetale========================

            // List<Book> bookList = context.Book.Include(b => b.Library).ToList();

            // var bookNameLibrery = AnsiConsole.Prompt(
            // new SelectionPrompt<string>()
            //.Title("Select a city")
            ///*.PageSize(5)*/
            //.MoreChoicesText("[grey](Use arrow keys to see more cities)[/]")
            //.AddChoices(bookList.Select(l => l.Title + " - " + l.Library.Name)));

            // AnsiConsole.MarkupLine($"You selected: [blue]{bookNameLibrery}[/]");

            // var bookName = bookNameLibrery.Split('-')[0].Trim();

            // int selectedBookId = bookList.FirstOrDefault(l => l.Title == bookName)?.Id ?? 0;

            // Console.Write("წიგნის გვერდების რაოდენობა: ");
            // var bookPagesInput = Console.ReadLine();
            // if (!int.TryParse(bookPagesInput, out var bookPages))
            // {
            //     AnsiConsole.MarkupLine($"[red]Invalid pages format.[/]");
            //     return;
            // }

            // Console.Write("წიგნის გამომცემლობა: ");
            // var bookPublisher = Console.ReadLine();
            // if(!int.TryParse(bookPagesInput, out var bookPublisherId))
            // {
            //     AnsiConsole.MarkupLine($"[red]Invalid publisher format.[/]");
            //     return;
            // }


            // string alphabet = "აბგდევზთიკლმნოპჟრსტუფქღყშჩცძწჭხჯჰ0123456789";

            // Random random = new Random();

            // string code = string.Join("-",
            //     Enumerable.Range(0, 5)
            //         .Select(_ => new string(
            //             Enumerable.Range(0, 4)
            //                 .Select(_ => alphabet[random.Next(alphabet.Length)])
            //                 .ToArray()
            //         ))
            // );





            // BookDetails bookDetails = new BookDetails
            // {
            //     PageCount = bookPages,
            //     PublishedYear = bookPublisherId,
            //     ISBN = code,
            //     BookId = selectedBookId
            // };

            // context.BookDetail.AddRange(bookDetails);
            // context.SaveChanges();

            //========================end bookDetale========================


            //========================================get bookDetale========================


            //List<Book> books = context.Book
            //                            .Include(b => b.Library)
            //                            .Include(b => b.BookDetails)
            //                            .ToList();


            //var table = new Table();

            //table.AddColumn("სათაური");
            //table.AddColumn("ავტორი");
            //table.AddColumn("ბიბლიოთეკა");
            //table.AddColumn("გვერდების რაოდენობა");
            //table.AddColumn("ფასი");

            ////table.AddRow("Alice", "North", "$12,400");
            ////table.AddRow("Bob", "South", "$8,750");
            ////table.AddRow("Carol", "West", "$15,200");


            //foreach (var item in books)
            //{
            //    var tt = item.Title;
            //    var tt1 = item.Author;
            //    var tt2 = item.Library.Name;
            //    var tt3 = item.BookDetails== null ? "N/A" : item.BookDetails.PageCount.ToString();
            //    var tt4 = item.Price == null ? "N/A" : item.Price.ToString();

            //    table.AddRow(
            //                    tt,
            //                    tt1,
            //                    tt2,
            //                    tt3,
            //                    tt4);
            //    //Console.WriteLine($"სათაური: {item.Title}, ბიბლიოთეკა: {item.Library.Name}");
            //}


            //AnsiConsole.Write(table);





            //========================end get bookDetale========================
            #endregion

        }
    }
}
