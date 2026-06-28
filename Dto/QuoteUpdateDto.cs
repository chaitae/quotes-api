namespace QuoteDatabase.Api.Dtos;

public record QuoteUpdateDto
{
    public string OldText { get; init; } = string.Empty;
    public string NewText { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
}