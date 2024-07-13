using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementInterface
{
    public class Employee : Person
    {
        private string position;
        internal string Position
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Cannot use empty value as a position");
                }
                else
                {
                    position = value;
                }
            }
            get
            {
                return position;
            }
        }

        public Employee(int ID, string Name, string? Position) : base(ID, Name)
        {
            this.Position = Position;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"The person with an ID of {ID} is named {Name} and works as {Position}");
        }
    }
}
