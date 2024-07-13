using StudentManagementInterface;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static Library library = new Library();

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Find Book by Title");
            Console.WriteLine("4. Find Book by ISBN");
            Console.WriteLine("5. List All Books");
            Console.WriteLine("6. Add Reader");
            Console.WriteLine("7. Remove Reader");
            Console.WriteLine("8. Find Reader");
            Console.WriteLine("9. Borrow Book");
            Console.WriteLine("10. Return Book");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    FindBookByTitle();
                    break;
                case "4":
                    FindBookByISBN();
                    break;
                case "5":
                    ListAllBooks();
                    break;
                case "6":
                    AddReader();
                    break;
                case "7":
                    RemoveReader();
                    break;
                case "8":
                    FindReader();
                    break;
                case "9":
                    BorrowBook();
                    break;
                case "10":
                    ReturnBook();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddBook()
    {
        Console.Clear();
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter book author: ");
        string author = Console.ReadLine();
        Console.Write("Enter book ISBN: ");

        string isbn = Convert.ToString(Console.ReadLine());
        Console.Write("Enter book year: ");
        int year = int.Parse(Console.ReadLine());

        Book book = new Book(title, author, isbn, year)
        {
            BookTitle = title,
            Author = author,
            ISBN = isbn,
            Year = year
        };

        library.AddBook(book);
        Console.WriteLine("Book added successfully.");
        Pause();
    }

    static void RemoveBook()
    {
        Console.Clear();
        Console.Write("Enter book ISBN: ");
        string isbn = Console.ReadLine();
        library.RemoveBook(isbn);
        Console.WriteLine("Book removed successfully.");
        Pause();
    }

    static void FindBookByTitle()
    {
        Console.Clear();
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        library.FindBookByTitle(title);
        Pause();
    }

    static void FindBookByISBN()
    {
        Console.Clear();
        Console.Write("Enter book ISBN: ");
        string isbn = Console.ReadLine();
        library.FindBookByISBN(isbn);
        Pause();
    }

    static void ListAllBooks()
    {
        Console.Clear();
        library.PrintBooks();
        Pause();
    }

    static void AddReader()
    {
        Console.Clear();
        Console.Write("Enter reader ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter reader name: ");
        string name = Console.ReadLine();

        Reader reader = new Reader(id, name);
        library.AddReader(reader);
        Console.WriteLine("Reader added successfully.");
        Pause();
    }

    static void RemoveReader()
    {
        Console.Clear();
        Console.Write("Enter reader ID: ");
        int id = int.Parse(Console.ReadLine());
        library.RemoveReader(id);
        Pause();
    }

    static void FindReader()
    {
        Console.Clear();
        Console.Write("Enter reader name: ");
        string name = Console.ReadLine();
        library.FindReader(name);
        Pause();
    }

    static void BorrowBook()
    {
        Console.Clear();
        Console.Write("Enter reader ID: ");
        int id = int.Parse(Console.ReadLine());
        Reader reader = library.Readers.FirstOrDefault(r => r.ID == id);
        if (reader == null)
        {
            Console.WriteLine("Reader not found.");
            Pause();
            return;
        }

        Console.Write("Enter book ISBN: ");
        string isbn = Console.ReadLine();
        library.BorrowBook(isbn, reader);
        Pause();
    }

    static void ReturnBook()
    {
        Console.Clear();
        Console.Write("Enter reader ID: ");
        int id = int.Parse(Console.ReadLine());
        Reader reader = library.Readers.FirstOrDefault(r => r.ID == id);
        if (reader == null)
        {
            Console.WriteLine("Reader not found.");
            Pause();
            return;
        }

        Console.Write("Enter book ISBN: ");
        string? isbn = Console.ReadLine();
        library.ReturnBook(isbn, reader);
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
