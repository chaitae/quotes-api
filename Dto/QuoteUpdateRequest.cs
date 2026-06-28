namespace QuoteDatabase.Api.Dtos;

public record QuoteUpdateRequest
{
    public string OldText { get; init; } = string.Empty;
    public string NewText { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
}