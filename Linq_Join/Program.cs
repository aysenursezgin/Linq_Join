using System;
using System.Collections.Generic;
using System.Linq;

class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
}

class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
}

class Program
{
    static void Main()
    {
        // Yazarlar ve kitaplar için örnek veriler
        List<Author> authors = new List<Author>
        {
            new Author { AuthorId = 1, Name = "J.K. Rowling" },
            new Author { AuthorId = 2, Name = "George Orwell" },
            new Author { AuthorId = 3, Name = "J.R.R. Tolkien" }
        };

        List<Book> books = new List<Book>
        {
            new Book { BookId = 1, Title = "Harry Potter and the Sorcerer's Stone", AuthorId = 1 },
            new Book { BookId = 2, Title = "1984", AuthorId = 2 },
            new Book { BookId = 3, Title = "The Hobbit", AuthorId = 3 },
            new Book { BookId = 4, Title = "Harry Potter and the Chamber of Secrets", AuthorId = 1 }
        };

        // LINQ sorgusu ile kitapları ve yazarları birleştiriyoruz
        var bookAuthorQuery = from book in books
                              join author in authors on book.AuthorId equals author.AuthorId
                              select new
                              {
                                  BookTitle = book.Title,
                                  AuthorName = author.Name
                              };

        // Sonuçları yazdırıyoruz
        Console.WriteLine("Kitaplar ve Yazarlar:");
        foreach (var item in bookAuthorQuery)
        {
            Console.WriteLine($"Kitap: {item.BookTitle}, Yazar: {item.AuthorName}");
        }

        // Programın bitişi
        Console.WriteLine("\nProgram sonlandırılıyor...");
    }
}

