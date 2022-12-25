using System.Data.SqlClient;
using Dapper;

namespace BookLibrary.Models
{
    public class BookDB
    {
        private string connectionString = ("server=nyctotampa; database=personal; user id=raju; password=raju123");
        //private string connectionString = ("server=KHALIFABUILD202; database=personal; user id=raju; password=raju123");
        public List<Book> getAllBooks()
        {
            List<Book> books = new List<Book>();
            string sql = "select * from Book";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                books = conn.Query<Book>(sql).ToList();
            }
            return books;
        }

        public Book GetBookById(int BookID)
        {
            var book = new Book();
            string sql = " select * from Book WHERE BookID =@BookID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                book = conn.QueryFirst<Book>(sql, new { BookID });
            }
            return book;
        }

        public void BookEditSave(Book book)
        {
            string sql;
            if (book.BookID == 0)
            {
                sql = "INSERT INTO [Book] " +
                        "(Title,NumberofPages,CreatedDate)" +

                      "VALUES" +
                        "(@Title, @NumberofPages, @CreatedDate)";
            }
            else
            {
                sql = "UPDATE Book SET " +
                        "Title = @Title, NumberofPages = @NumberofPages, UpdatedDate = @UpdatedDate " +
                      "WHERE BookID = @BookID";

            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(sql, book);
            }
        }

        public void DeleteBook(int BookID)
        {
            string sql = "DELETE FROM [Book] WHERE [BookID] = @BookID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(sql, new { BookID });
            }

        }
    }
}
