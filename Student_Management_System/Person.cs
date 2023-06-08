using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Person
    {
        public string Name;
        public int Age;

        public Person()
        {
        }

        public virtual void DisplayInfo()
        {
            //this is gonna be executed if no person has been selectd
            Console.WriteLine("please select at least 1 student to display his info !");
        }
        
    }
}
