using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookLibrary.Controllers
{
    public class BookController : Controller
    {
        public IActionResult ReadBooks()
        {
            ViewBag.FileErrorMessage = TempData["FileErrorMessage"];
            HttpClient client = new HttpClient();
            var responseTask = client.GetAsync("https://localhost:5173/api/BookAPI");
            responseTask.Wait();
            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var MessageTask = result.Content.ReadAsStringAsync();
                    var str = MessageTask.Result;
                    var books = JsonConvert.DeserializeObject<List<Book>>(MessageTask.Result);
                    ViewBag.Book = books;
                }
            }
            return View();
        }

        public IActionResult SaveCreateAndUpdateBook(Book book)
        {
            BookDB bookDb = new BookDB();
            if (book.BookID == 0)
            {
                book.CreatedDate = DateTime.Now;
                HttpClient client = new HttpClient();
                var responseTask = client.PostAsJsonAsync("https://localhost:5173/api/BookAPI/", book);
                responseTask.Wait();
            }
            else
            {
                book.UpdatedDate = DateTime.Now;
                HttpClient client = new HttpClient();
                var responseTask = client.PutAsJsonAsync("https://localhost:5173/api/BookAPI/" + book.BookID, book);
                responseTask.Wait();
            }
            return RedirectToAction("ReadBooks");
        }

        public IActionResult CreateAndUpdateBook(Book book)
        {
            ViewBag.errorMessage = TempData["errorMessage"];

            if ((ViewBag.errorMessage == null) && (book.BookID != 0))
            {
                HttpClient client = new HttpClient();
                var responseTask = client.GetAsync("https://localhost:5173/api/BookAPI/" + book.BookID);
                responseTask.Wait();
                if (responseTask.IsCompleted)
                {
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var MessageTask = result.Content.ReadAsStringAsync();
                        var str = MessageTask.Result;
                        var bookToUpdate = JsonConvert.DeserializeObject<Book>(MessageTask.Result);
                        ViewBag.Book = bookToUpdate;
                    }
                }
            }
            else
                ViewBag.Book = book;
            return View();
        }

        public IActionResult DeleteBook(int BookID)
        {
            HttpClient client = new HttpClient();
            var responseTask = client.DeleteAsync("https://localhost:5173/api/BookAPI/" + BookID);
            responseTask.Wait();
            return RedirectToAction("ReadBooks");
        }

        public IActionResult ExportBookToCSV()
        {
            BookDB bookDB = new BookDB();
            List<Book> books = bookDB.getAllBooks();

            var builder = new StringBuilder();
            builder.AppendLine("BookID, Title, NumberofPages, CreatedDate, UpdatedDate");

            foreach (var book in books)
            {
                builder.AppendLine($"{book.BookID}, {book.Title}, {book.NumberofPages}, {book.CreatedDate}, {book.UpdatedDate}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Book.csv");
        }
    }
}
