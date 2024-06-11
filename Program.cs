
using GameStore.Api.Entities;

List<Game> games =
[
    new Game
    {
        Id = 1,
        Name = "CS GO2.0",
        Genre = "Simple",
        Price = 19.99M,
        ReleaseDate = new DateTime(),
        ImageUri = "https://placehold.co/100"
    }
];

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
