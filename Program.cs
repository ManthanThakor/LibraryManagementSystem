using System;

namespace LibraryManagmentSystem
{

    public class Author
    {
        public string Name { get; set; }
        public string Bio { get; set; }

        public Author(string name, string bio)
        {
            Name = name;
            Bio = bio;
        }
    }

    public class Book
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }

    public class Library
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\"LIBRARY MANAGMENT SYSTEM\"");

           

            Console.ReadLine();
        }
    }
}
