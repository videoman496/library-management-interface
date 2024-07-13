using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementInterface
{
    internal interface IBorrowable
    {
        void Borrow(Book book);
        void Return(Book book);
    }
}
