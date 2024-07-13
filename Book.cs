using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementInterface
{
    public class Book
    {
        public Book(string BookTitle,string Author, string ISBN, int Year) { }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public int Year { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"The book {BookTitle} was written in {Year} by {Author} and has an ISBN of {ISBN}");
        }
    }
}
