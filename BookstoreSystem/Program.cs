using System;
using System.Collections.Generic;

namespace BookstoreSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Bookstore bookstore = new Bookstore();
            bookstore.AddBook(new Book("1001", "The Great Gatsby", "F. Scott Fitzgerald", 1925, Genre.Fiction));
            bookstore.AddBook(new Book("1002", "To Kill a Mockingbird", "Harper Lee", 1960, Genre.Fiction));
            bookstore.AddBook(new Book("1003", "1984", "George Orwell", 1949, Genre.Fiction));

            Console.WriteLine("📚 Initial list of books:");
            bookstore.DisplayBooks();

            Book newBook = new Book("1004", "Pride and Prejudice", "Jane Austen", 1813, Genre.Fiction);
            bookstore.AddBook(newBook);
            Console.WriteLine("\n✅ Added a new book:");
            bookstore.DisplayBooks();

            Book updatedBook = new Book("1003", "1984", "George Orwell", 1949, Genre.Dystopian);
            bookstore.UpdateBook("1003", updatedBook);
            Console.WriteLine("\n🔄 Updated book details:");
            bookstore.DisplayBooks();

            bookstore.DeleteBook("1002");
            Console.WriteLine("\n❌ Deleted a book:");
            bookstore.DisplayBooks();
        }
    }

    public enum Genre
    {
        Fiction,
        NonFiction,
        Dystopian,
        Mystery,
        Romance,
        Thriller
    }

    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }

        public Book(string isbn, string title, string author, int year, Genre genre)
        {
            ISBN = isbn ?? throw new ArgumentNullException(nameof(isbn), "ISBN cannot be null.");
            Title = title ?? throw new ArgumentNullException(nameof(title), "Title cannot be null.");
            Author = author ?? throw new ArgumentNullException(nameof(author), "Author cannot be null.");
            Year = year;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} ({Year}), Genre: {Genre}";
        }
    }

    public class Bookstore
    {
        private readonly List<Book> books;

        public Bookstore()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("❌ Cannot add a null book.");
                return;
            }

            books.Add(book);
            Console.WriteLine($"✅ Book '{book.Title}' added successfully.");
        }

        public void UpdateBook(string isbn, Book updatedBook)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("❌ ISBN cannot be empty.");
                return;
            }

            int index = books.FindIndex(b => b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                books[index] = updatedBook;
                Console.WriteLine($"🔄 Book with ISBN {isbn} updated successfully.");
            }
            else
            {
                Console.WriteLine($"❌ Book with ISBN {isbn} not found.");
            }
        }

        public void DeleteBook(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("❌ ISBN cannot be empty.");
                return;
            }

            Book bookToRemove = books.Find(b => b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));

            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine($"❌ Book '{bookToRemove.Title}' removed successfully.");
            }
            else
            {
                Console.WriteLine($"❌ Book with ISBN {isbn} not found.");
            }
        }

        public void DisplayBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("📂 No books available in the store.");
                return;
            }

            Console.WriteLine("📖 Available Books:");
            foreach (var book in books)
            {
                Console.WriteLine($"➡️ {book}");
            }
        }
    }
}