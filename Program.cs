using Microsoft.AspNetCore.Mvc;
using QuoteDatabase.Api.Dtos;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//that {userID} is referred to as a route parameter
app.MapGet("/user/{userId}", (string userID) => $"user id given: {userID}");
List<QuoteDto> quotes = new List<QuoteDto>();
//let's do a quote database for practice
//start by making a record dto type reference? Oh right you want to make one for posting/deleting whatevs
//okay let's just set u some crud endpoints for reference
//now let's just make this a like.. just posts? iunno you want a useful database
//Get
app.MapGet("/quote/{id}",(int id) =>
{
    var quote = quotes.Find(q => q.Id == id);
    if (quote is null)
        return Results.NotFound();

    return Results.Ok(quote);
});
//for now get by id

//Put
//you don't know the syntax to put in a json we googled mappost and found it
//looks like map post also takes a lambda or function that returns results.Created so let's do that
app.MapPost("/AddQuote",(QuotePostDto quotePostDto) =>
{
    var quote = new QuoteDto
    {
        Id = quotes.Count,
        Text = quotePostDto.Text,
        Author = quotePostDto.Author,
        CreatedAt = DateTime.Now
    };
    quotes.Add(quote);
   return Results.Created($"/quotes/{quotePostDto.Text}",quotePostDto); 
});
//Update
// app.MapPut("/UpdateQuote",(QuoteUpdateDto quoteUpdateDto)=>
// {
    
// }
//delete

//we need to create record type for quote database
app.Run();
