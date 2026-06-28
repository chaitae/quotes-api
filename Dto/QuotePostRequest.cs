namespace QuoteDatabase.Api.Dtos;

public record QuotePostRequest
{    
    public string Text { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
}