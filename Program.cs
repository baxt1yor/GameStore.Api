
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
    },
    new Game
    {
        Id = 2,
        Name = "CS GO2.0222",
        Genre = "Simple2",
        Price = 39.99M,
        ReleaseDate = new DateTime(),
        ImageUri = "https://placehold.co/300"
    },
    new Game
    {
        Id = 3,
        Name = "CS GO2.033",
        Genre = "Simple33",
        Price = 333.99M,
        ReleaseDate = new DateTime(),
        ImageUri = "https://placehold.co/200"
    }
    
];

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var group = app.MapGroup("games");

app.MapGet("/", () => "Hello World!");
group.MapGet("/", () => games);
group.MapGet("/{id:int}", (int id) =>
{
    var game = games.Find(item => item.Id == id);
    return game is null ? Results.NotFound("Game Not found!") : Results.Ok(game);
});

group.MapPost("/", (Game game) =>
{
    game.Id = games.Max(item => item.Id) + 1;
    games.Add(game);
    return Results.Ok("Added!");
});

group.MapDelete("/{id:int}", (int id) =>
{
    var game = games.Find(item => item.Id == id);
    if (game is not null)
    {
        games.Remove(game);
    }

    return Results.NoContent();
});
app.Run();
