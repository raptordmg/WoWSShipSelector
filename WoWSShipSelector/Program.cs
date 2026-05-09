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

var ships = new List<Ship>();

// Add ship population from WG API here

app.MapGet("/randomship", () =>
{
    return ships[Random.Shared.Next(ships.Count)];
})
.WithName("GetRandomShip");

app.Run();

internal record Ship(int Tier, string Name, Nation Nation, ShipType Type, bool IsPremium, bool IsSpecial, string ShipIdStr);

internal enum Nation
{
    Usa = 0,
    Japan = 1,
    Ussr = 2,
    Uk = 3,
    Germany = 4,
    Europe = 5,
    PanAsia = 6,
    France = 7,
    Commonwealth = 8,
    Italy = 9,
    PanAmerica = 10,
    Netherlands = 11,
    Spain = 12
}

internal enum ShipType
{
    AirCarrier = 0,
    Battleship = 1,
    Destroyer = 2,
    Cruiser = 3,
    Submarine = 4
}
