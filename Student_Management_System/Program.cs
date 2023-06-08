using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Management_System
{
    class Program
    {

        static void Main(string[] args)
        {
            DataStorage<Student> s = new DataStorage<Student>();
            _menu(s);
        }

        private static void _menu(DataStorage<Student> s)
        {

            List<string> menuList = new List<string> { "Show Student", "Add Grades", "Register Students" };
            Console.WriteLine("Please enter a value from 1 to 3 to enter a menu");
            while (true)
            {
                foreach (var menuItem in menuList)
                {
                   
                    Console.WriteLine(menuItem);
                }

                char c = Console.ReadKey().KeyChar;
                if (c == '1')
                    _displayStudents(s);
                else if (c == '2')
                    _evaluateStudent(s);
                else if (c == '3')
                    _registerStudents(s);
            }
        }
        private static bool _addMoreStudents()
        {
            Console.WriteLine("Add More ? (Y or N)");
            var c = Console.ReadKey().KeyChar;
            if (c == 'N' || c == 'n')
            {
                return false;
            }
            return true;
        }
        private static void _registerStudents(DataStorage<Student> s)
        {

            bool addMore = true;
            while (addMore)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Enter the students Name:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Enter the students Age: ");
                    var age = Console.ReadLine();

                    s.Add(new Student { Name = name, Age = Convert.ToInt32(age) });
                    addMore = _addMoreStudents();


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }
        private static void _evaluateStudent(DataStorage<Student> s)
        {
            //addingn grades to existing students
            Console.WriteLine("First find the student you want to evaluate and begin the evaluation");
            List<Student> students = _searchBy(s);
            foreach (var student in students)
            {
                Console.WriteLine($"Grade for {student.Name}");
                string grade = Console.ReadLine();
                if (int.TryParse(grade, out int n))
                {
                    student.Grades = Convert.ToDouble(grade);
                }
            }


        }
        private static void _displayStudents(DataStorage<Student> s)
        {
            Console.WriteLine("Filter or display all ? 1 or 2");
            char c = Console.ReadKey().KeyChar;
            if (c == '1')
            {
                foreach (var student in _searchBy(s))
                {
                    student.DisplayInfo();
                }

            }
            else
            {
                foreach (var st in s.Get())
                {
                    st.DisplayInfo();
                }
            }

        }

        private static List<Student> _searchBy(DataStorage<Student> s)
        {
            List<string> filters = new List<string> { "Name", "Age", "Grades" };
            var students = s.Get();
            List<Student> find = new();
            while (true)
            {
                foreach (var filter in filters)
                {
                    Console.WriteLine(filter);

                }
                Console.WriteLine("What is your choice ?");
                char c = Console.ReadKey().KeyChar;
                Console.Clear();

                if (c == '1')
                {
                    Console.WriteLine("enter a sequence of name like gl or enn to find Glenn");
                    string name = Console.ReadLine();
                    find = students.Where(x => x.Name.Contains(name)).ToList();
                    break;
                }
                else if (c == '2')
                {
                    Console.WriteLine("enter an Age like 12");
                    string age = Console.ReadLine();
                    if (int.TryParse(age, out int n))
                        find = students.Where(x => x.Age == Convert.ToInt32(age)).ToList();
                    break;
                }
                else if (c == '3')
                {
                    Console.WriteLine("enter a Grade like 5");
                    string grade = Console.ReadLine();

                    if (int.TryParse(grade, out int n))
                        find = students.Where(x => x.Age == Convert.ToInt32(grade)).ToList();
                    break;
                }
                else
                {
                    Console.WriteLine("try Again");
                }
            }

            return find;

        }
    }
}
