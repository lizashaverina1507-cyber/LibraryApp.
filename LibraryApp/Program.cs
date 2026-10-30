namespace LibraryApp;

internal sealed class Program
{
    static void Main()
    {
        Library library = CreateLibrary();
        RunScenarios(library);
        PrintBooks(library);
    }

    // Создаёт библиотеку с тестовыми книгами.
    private static Library CreateLibrary()
    {
        var library = new Library();
        library.AddBook(new Book
        {
            Id = 1,
            Title = "Война и мир",
            Author = "Л. Толстой"
        });
        library.AddBook(new Book
        {
            Id = 2,
            Title = "Преступление и наказание",
            Author = "Ф. Достоевский"
        });
        library.AddBook(new Book
        {
            Id = 3,
            Title = "Мастер и Маргарита",
            Author = "М. Булгаков"
        });
        return library;
    }

    // Выполняет обычные и граничные сценарии.
    private static void RunScenarios(Library library)
    {
        library.AddBook(new Book
        {
            Id = 1,
            Title = "Дубликат",
            Author = "Неизвестен"
        });
        library.BorrowBook(1);
        library.BorrowBook(1);
        library.ReturnBook(2);
        library.ReturnBook(1);
        library.BorrowBook(99);
    }

    // Выводит текущее состояние всех книг.
    private static void PrintBooks(Library library)
    {
        Console.WriteLine("Состояние библиотеки:");
        foreach (Book book in library.GetBooks())
        {
            string status = book.IsAvailable ? "доступна" : "выдана";
            Console.WriteLine(
                $"{book.Id}. {book.Title} ({book.Author}) - {status}");
        }
    }
}