using AtosEvidenBackendService.Controllers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();
app.UseRouting();
app.UseCors("AllowLocalhost4200");


app.MapGet("/allPokemons", () => {
    var pokemons = UserRepositoryController.pokemons;

    var jsonResponse = new OkObjectResult(pokemons);
    return jsonResponse;
});

app.Run();

