using Microsoft.AspNetCore.Mvc;
using QuoteDatabase.Api.Dtos;
using QuoteDatabase.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
var app = builder.Build();
app.MapQuoteEndpoints();

app.Run();
