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
        public string Title { get; set; }
        public Author[] Authors { get; set; } 
        public string ISBN { get; set; }

        public Book(string title, string isbn, Author[] authors)
        {
            Title = title;
            ISBN = isbn;
            Authors = authors;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, ISBN: {ISBN}");
            Console.Write("Authors: ");
            foreach (var author in Authors)
            {
                Console.Write(author.Name + " ");
            }
            Console.WriteLine();
        }
    }

    public class Library
    {
        private Book[] books;
        private int currentIndex;

        public Library(int capacity)
        {
            books = new Book[capacity];
            currentIndex = 0;
        }

        public void AddBook(Book book)
        {
            if (currentIndex < books.Length)
            {
                books[currentIndex] = book;
                currentIndex++;
            }
            else
            {
                Console.WriteLine("Library is full, can't add more books.");
            }
        }

        public void SearchByTitle(string title)
        {
            bool found = false;
            for (int i = 0; i < currentIndex; i++)
            {
                if (books[i].Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                {
                    books[i].DisplayInfo();
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No books found with the specified title.");
            }
        }

        public void SearchByAuthor(string authorName)
        {
            bool found = false;
            for (int i = 0; i < currentIndex; i++)
            {
                foreach (var author in books[i].Authors)
                {
                    if (author.Name.Contains(authorName, StringComparison.OrdinalIgnoreCase))
                    {
                        books[i].DisplayInfo();
                        found = true;
                        break;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("No books found by the specified author.");
            }
        }

        public void ListAllBooks()
        {
            if (currentIndex == 0)
            {
                Console.WriteLine("No books available in the library.");
            }
            else
            {
                for (int i = 0; i < currentIndex; i++)
                {
                    books[i].DisplayInfo();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\"LIBRARY MANAGMENT SYSTEM\"");

            // Creating authors
            Author author1 = new Author("J.K. Rowling", "British author, best known for the Harry Potter series.");
            Author author2 = new Author("J.R.R. Tolkien", "English author and academic, known for The Lord of the Rings.");

            // Creating books
            Book book1 = new Book("Harry Potter and the Sorcerer's Stone", "978-0747532699", new Author[] { author1 });
            Book book2 = new Book("The Lord of the Rings", "978-0618640157", new Author[] { author2 });
            Book book3 = new Book("Harry Potter and the Chamber of Secrets", "978-0747538493", new Author[] { author1 });

            // Creating library
            Library library = new Library(5);  
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            // Listing all books in the library
            Console.WriteLine("Listing all books in the library:");
            library.ListAllBooks();

            // Searching for books by title
            Console.WriteLine("\nSearching for books by title (Harry Potter):");
            library.SearchByTitle("Harry Potter");

            // Searching for books by author
            Console.WriteLine("\nSearching for books by author (J.K. Rowling):");
            library.SearchByAuthor("J.K. Rowling");

            Console.ReadLine();
        }
    }

}
