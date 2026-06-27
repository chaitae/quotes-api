namespace QuoteDatabase.Api.Dtos;

public record QuotePostDto
{    
    public string Text { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
}