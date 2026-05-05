var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi/test.yaml");
}

app.UseHttpsRedirection();

var names = new[]
{
    "Warspite", "Yamato", "Iowa", "Bismarck"
};

app.MapGet("/randomship", () =>
{
    var ship = new Ship
        (
            Random.Shared.Next(1, 10),
            Random.Shared.Next(-20, 55),
            names[Random.Shared.Next(names.Length)]
        );
    return ship;
})
.WithName("GetRandomShip");

app.Run();

internal record Ship(int Tier, int ShipId, string? Name);
