using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class DataStorage<T>
    {
        //declare your variables. it should only be accessible from its own class !
        private List<T> _data;

        //generate a constructor and initialize your variable declared earlier
        public DataStorage()
        {
            _data = new List<T>();
        }

        //Add a function in order to add items to the private variable
        public void Add(T data)
        {
            //add items to list by passed arg 
            _data.Add(data);
            Console.WriteLine($"{data} added to lsit");

        }
        public List<T> Get()
        {
            //return _data that way it is accessible for other people with limitations (we call this encapsulation it is a oop concept !)
            return _data;

        }
        public void Remove(T data)
        {
            //remove item using passed parameter
            _data.Remove(data);
            Console.WriteLine($"{data} remove from lsit");
        }

        public void Clear()
        {
            //empty list 
            _data.Clear();
            Console.WriteLine($"list has been cleared out");

        }
    }
}
