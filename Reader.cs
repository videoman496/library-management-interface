namespace StudentManagementInterface
{
    public class Reader : Person, IBorrowable
    {
        public List<Book> BorrowedBooks { get; set; }
        public DateTime MembershipDate { get; set; }
        public Reader(int id, string name) : base(id, name)
        {
            BorrowedBooks = new List<Book>();
            MembershipDate = DateTime.Now;
        }

        public void Borrow(Book book)
        {
            BorrowedBooks.Add(book);
        }

        public void Return(Book book)
        {
            BorrowedBooks.Remove(book);
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Membership Date: {MembershipDate}");
            Console.WriteLine("Borrowed Books:");
            foreach (var book in BorrowedBooks)
            {
                book.PrintInfo();
            }
        }
    }

}