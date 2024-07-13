using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementInterface
{
    public class Person
    {
        internal int ID { get; set; }
        private string name;
        internal string Name
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Cannot use empty value as a name");
                }
                else
                {
                    name = value;
                }
            }
            get
            {
                return name;
            }
        }
        public Person(int ID, string? Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"The person with an ID of {ID} is named {Name}");
        }
    }
}
