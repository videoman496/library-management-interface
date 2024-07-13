using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
namespace StudentManagementInterface
{
    public class Library
    {
        public List<Book> Books { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Reader> Readers { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Employees = new List<Employee>();
            Readers = new List<Reader>();
        }

        public void RemoveBook(string ISBN)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == ISBN);
            if (book != null)
            {
                Books.Remove(book);
            }
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public Book FindBookByTitle(string title)
        {
            foreach (var book in Books)
            {
                if (book.BookTitle == title)
                {
                    return book;
                }
            }
            return null;
        }

        public void FindBookByISBN(string ISBN)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == ISBN);
            if (book != null)
            {
                Console.WriteLine($"Here's what we've found about \"{ISBN}\": item's name is {book.BookTitle}, it was written in {book.Year} by {book.Author}.");
            }
            else
            {
                Console.WriteLine("Couldn't find any book with this ISBN.");
            }
        }

        public void PrintBooks()
        {
            foreach (var book in Books)
            {
                Console.WriteLine($"{book.BookTitle}, {book.Author}, {book.Year}, {book.ISBN}");
            }
        }

        public void AddReader(Reader reader)
        {
            Readers.Add(reader);
            Console.WriteLine($"{reader.Name} was added to readers list.");
        }

        public void RemoveReader(int id)
        {
            var reader = Readers.FirstOrDefault(r => r.ID == id);
            if (reader != null)
            {
                Readers.Remove(reader);
                Console.WriteLine($"Reader with ID {id} was removed.");
            }
            else
            {
                Console.WriteLine("Reader you are trying to remove was not found.");
            }
        }

        public void FindReader(string name)
        {
            var reader = Readers.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (reader != null)
            {
                Console.WriteLine($"We found {name}, it's {reader.Name}.");
            }
            else
            {
                Console.WriteLine("Reader you are trying to find was not found.");
            }
        }

        public void BorrowBook(string ISBN, Reader reader)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == ISBN);
            if (book != null)
            {
                reader.Borrow(book);
                Books.Remove(book);
                Console.WriteLine($"{book.BookTitle} has been borrowed by {reader.Name}.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void ReturnBook(string ISBN, Reader reader)
        {
            var book = reader.BorrowedBooks.FirstOrDefault(b => b.ISBN == ISBN);
            if (book != null)
            {
                reader.Return(book);
                Books.Add(book);
                Console.WriteLine($"{book.BookTitle} has been returned by {reader.Name}.");
            }
            else
            {
                Console.WriteLine("Book not found in reader's borrowed books.");
            }
        }
    }
}
