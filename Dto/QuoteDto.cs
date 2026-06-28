using System.ComponentModel.DataAnnotations;

namespace QuoteDatabase.Api.Dtos;

public record QuoteDto
{
    public int Id { get; init; }
    [Required] public string Text { get; init; } = string.Empty;
    [Required] public string Author { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}