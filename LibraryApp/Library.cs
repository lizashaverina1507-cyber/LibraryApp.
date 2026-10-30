namespace LibraryApp;

/// <summary>
/// Библиотека: хранит книги, выдаёт и принимает их обратно.
/// </summary>
public class Library
{
    private readonly List<Book> _books = new();

    /// <summary>
    /// Добавляет книгу в библиотеку.
    /// </summary>
    /// <param name="book">Добавляемая книга.</param>
    /// <exception cref="ArgumentNullException">book = null.</exception>
    public void AddBook(Book book)
    {
        ArgumentNullException.ThrowIfNull(book);

        if (FindBook(book.Id) != null)
        {
            Console.WriteLine(
                $"Ошибка: книга с Id = {book.Id} уже существует.");
            return;
        }

        _books.Add(book);
    }

    /// <summary>
    /// Ищет книгу по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор книги.</param>
    /// <returns>Книга или null, если её нет.</returns>
    public Book? FindBook(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    /// <summary>
    /// Выдаёт книгу читателю.
    /// </summary>
    /// <param name="id">Идентификатор книги.</param>
    /// <returns>true – выдана, false – выдача невозможна.</returns>
    public bool BorrowBook(int id)
    {
        Book? book = FindBookOrReport(id);
        if (book == null)
        {
            return false;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine(
                $"Ошибка: книга «{book.Title}» уже выдана.");
            return false;
        }

        book.IsAvailable = false;
        Console.WriteLine($"Книга выдана: {book.Title}");
        return true;
    }

    /// <summary>
    /// Принимает книгу обратно в библиотеку.
    /// </summary>
    /// <param name="id">Идентификатор книги.</param>
    /// <returns>true – возвращена, false – возврат невозможен.</returns>
    public bool ReturnBook(int id)
    {
        Book? book = FindBookOrReport(id);
        if (book == null)
        {
            return false;
        }

        if (book.IsAvailable)
        {
            Console.WriteLine(
                $"Ошибка: книга «{book.Title}» не была выдана.");
            return false;
        }

        book.IsAvailable = true;
        Console.WriteLine($"Книга возвращена: {book.Title}");
        return true;
    }

    /// <summary>
    /// Возвращает список всех книг только для чтения.
    /// </summary>
    public IReadOnlyList<Book> GetBooks()
    {
        return _books.AsReadOnly();
    }

    // Ищет книгу для выдачи или возврата; если её нет, выводит сообщение.
    private Book? FindBookOrReport(int id)
    {
        Book? book = FindBook(id);
        if (book == null)
        {
            Console.WriteLine($"Ошибка: книга с Id = {id} не найдена.");
        }

        return book;
    }
}