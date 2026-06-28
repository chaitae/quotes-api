namespace QuoteDatabase.Api.Endpoints;
using QuoteDatabase.Api.Dtos;

public static class QuotesEndpoints
{
    static List<QuoteDto> quotes = new List<QuoteDto>
    {
        new() { Id = 1, Text = "Be yourself", Author = "Oscar Wilde", CreatedAt = DateTime.UtcNow },
        new() { Id = 2, Text = "Stay hungry", Author = "Steve Jobs", CreatedAt = DateTime.UtcNow }
    };

    public static void MapQuoteEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/quotes");
        // app.MapGet("/user/{userId}", (string userID) => $"user id given: {userID}");

        group.MapGet("/{id}", (int id) =>
        {
            var quote = quotes.Find(q => q.Id == id);
            if (quote is null)
                return Results.NotFound();

            return Results.Ok(quote);
        });

        group.MapPost("/", (QuotePostRequest quotePostRequest) =>
        {
            var quote = new QuoteDto
            {
                Id = quotes.Any() ? quotes.Max(q => q.Id) + 1 : 1,
                Text = quotePostRequest.Text,
                Author = quotePostRequest.Author,
                CreatedAt = DateTime.Now
            };
            quotes.Add(quote);
            return Results.Created($"/quotes/{quote.Id}", quote);
        });

        group.MapPut("/", (QuoteUpdateRequest quoteUpdateRequest) =>
        {
            var quoteIndex = quotes.FindIndex(q => q.Text == quoteUpdateRequest.OldText);
            if (quoteIndex == -1)
            {
                return Results.NoContent();
            }
            var updatedQuote = quotes[quoteIndex] with
            {
                Text = quoteUpdateRequest.NewText
            };
            quotes[quoteIndex] = updatedQuote;
            return Results.Accepted();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            var quote = quotes.FirstOrDefault(q => q.Id == id);
            if (quote is null) return Results.NotFound();
            quotes.Remove(quote);
            return Results.NoContent();
        });
    }
}