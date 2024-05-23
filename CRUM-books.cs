using System;
using System.Collections.Generic;

namespace BookstoreSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize bookstore with some initial books
            Bookstore bookstore = new Bookstore();
            bookstore.AddBook(new Book("1001", "The Great Gatsby", "F. Scott Fitzgerald", 1925, Genre.Fiction));
            bookstore.AddBook(new Book("1002", "To Kill a Mockingbird", "Harper Lee", 1960, Genre.Fiction));
            bookstore.AddBook(new Book("1003", "1984", "George Orwell", 1949, Genre.Fiction));

            // Display initial list of books
            Console.WriteLine("Initial list of books:");
            bookstore.DisplayBooks();

            // Add a new book
            Book newBook = new Book("1004", "Pride and Prejudice", "Jane Austen", 1813, Genre.Fiction);
            bookstore.AddBook(newBook);
            Console.WriteLine("\nAdded a new book:");
            bookstore.DisplayBooks();

            // Update an existing book
            Book updatedBook = new Book("1003", "1984", "George Orwell", 1949, Genre.Dystopian);
            bookstore.UpdateBook("1003", updatedBook);
            Console.WriteLine("\nUpdated book details:");
            bookstore.DisplayBooks();

            // Delete a book
            bookstore.DeleteBook("1002");
            Console.WriteLine("\nDeleted a book:");
            bookstore.DisplayBooks();
        }
    }

    // Enum for book genres
    public enum Genre
    {
        Fiction,
        NonFiction,
        Dystopian,
        Mystery,
        Romance,
        Thriller
    }

    // Book class
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }

        public Book(string isbn, string title, string author, int year, Genre genre)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Year = year;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} ({Year}), Genre: {Genre}";
        }
    }

    // Bookstore class
    public class Bookstore
    {
        private List<Book> books;

        public Bookstore()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void UpdateBook(string isbn, Book updatedBook)
        {
            int index = books.FindIndex(b => b.ISBN == isbn);
            if (index != -1)
            {
                books[index] = updatedBook;
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void DeleteBook(string isbn)
        {
            Book bookToRemove = books.Find(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void DisplayBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
