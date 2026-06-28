using Microsoft.AspNetCore.Mvc;
using QuoteDatabase.Api.Dtos;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//that {userID} is referred to as a route parameter
app.MapGet("/user/{userId}", (string userID) => $"user id given: {userID}");
var quotes = new List<QuoteDto>
{
    new() { Id = 1, Text = "Be yourself", Author = "Oscar Wilde", CreatedAt = DateTime.UtcNow },
    new() { Id = 2, Text = "Stay hungry", Author = "Steve Jobs", CreatedAt = DateTime.UtcNow }
};
//let's do a quote database for practice
//start by making a record dto type reference? Oh right you want to make one for posting/deleting whatevs
//okay let's just set u some crud endpoints for reference
//now let's just make this a like.. just posts? iunno you want a useful database
//Get
app.MapGet("/quotes/{id}",(int id) =>
{
    var quote = quotes.Find(q => q.Id == id);
    if (quote is null)
        return Results.NotFound();

    return Results.Ok(quote);
});
//for now get by id

//you don't know the syntax to put in a json we googled mappost and found it
//looks like map post also takes a lambda or function that returns results.Created so let's do that
app.MapPost("/quotes",(QuotePostDto quotePostDto) =>
{
    var quote = new QuoteDto
    {
        Id = quotes.Any() ? quotes.Max(q=> q.Id)+1:1,
        Text = quotePostDto.Text,
        Author = quotePostDto.Author,
        CreatedAt = DateTime.Now
    };
    quotes.Add(quote);
   return Results.Created($"/quotes/{quote.Id}",quote); 
});
//Update
app.MapPut("/quotes",(QuoteUpdateDto quoteUpdateDto)=>
{
    var quoteIndex= quotes.FindIndex(q => q.Text == quoteUpdateDto.OldText);
    if(quoteIndex== -1)
    {
        return Results.NoContent();
    }
    var updatedQuote = quotes[quoteIndex] with
    {
        Text = quoteUpdateDto.NewText
    };
    quotes[quoteIndex] = updatedQuote;
    return Results.Accepted();
});
//delete
app.MapDelete("/quotes/{id}", (int id) =>
{ 
    var quote = quotes.FirstOrDefault(q => q.Id == id);
    if(quote is null) return Results.NotFound();
    quotes.Remove(quote);
    return Results.NoContent();
});

//we need to create record type for quote database
app.Run();
