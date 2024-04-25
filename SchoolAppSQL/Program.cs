using SchoolAppSQL.DataAccess;
using SchoolAppSQL.Models;

//Book book = new Book(1, "Bob", "Bob and his burgers", 300, 25);

//Console.WriteLine(book.ToString());

BookDBHandler BookDB = new BookDBHandler();

List<Book> books = BookDB.Get();

foreach (Book book in books)
{
    Console.WriteLine(book.ToString() + "\n");
}

Console.WriteLine(BookDB.Get(8).ToString());

Console.WriteLine();
