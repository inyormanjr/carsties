using AuctionService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//add dbcontext to the container
builder.Services.AddDbContext<AuctionDbContext>(options =>
   {
       options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
   });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseAuthorization();

app.MapControllers();

try
{
    app.InitDbInitializer();
}
catch (System.Exception e)
{
    Console.WriteLine(e);
}

app.Run();
