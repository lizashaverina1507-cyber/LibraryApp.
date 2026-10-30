namespace LibraryApp;

/// <summary>
/// Книга библиотеки.
/// </summary>
public class Book
{
    /// <summary>Уникальный идентификатор книги.</summary>
    public int Id { get; set; }

    /// <summary>Название книги.</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>Автор книги.</summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>Признак доступности книги для выдачи.</summary>
    public bool IsAvailable { get; set; } = true;
}