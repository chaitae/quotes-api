namespace QuoteDatabase.Api.Dtos;

public record QuoteDto
{
    public int Id { get; init; }
    public string Text { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}