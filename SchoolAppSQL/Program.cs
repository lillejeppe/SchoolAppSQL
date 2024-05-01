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

bool success = BookDB.Create(new Book(20, "HELP", "HEEELP", 500, 5));

if (success) Console.WriteLine(BookDB.Get(20).ToString());

Console.WriteLine("\n");

Console.WriteLine(BookDB.Get(20).ToString());

success = BookDB.Update(new Book(100, "Gamer", "Gamerfuel", 1000, 20), 20);

if (success) Console.WriteLine("\nBook updated\n");

Console.WriteLine(BookDB.Get(100).ToString());

success = BookDB.Delete(100);

if (success) Console.WriteLine("\nBook removed\n");

books = BookDB.Get();

foreach (Book book in books)
{
    Console.WriteLine(book.ToString() + "\n");
}

Console.WriteLine();
