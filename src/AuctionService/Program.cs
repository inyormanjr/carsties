using AuctionService.Data;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using AuctionService.Consumers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//add dbcontext to the container
builder.Services.AddDbContext<AuctionDbContext>(options =>
   {
       options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
   });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMassTransit(x  => {
    
    x.AddEntityFrameworkOutbox<AuctionDbContext>(
        o => {
            o.QueryDelay = TimeSpan.FromSeconds(10);
            o.UsePostgres();
            o.UseBusOutbox();
        }
    );

    x.AddConsumersFromNamespaceContaining<AuctionCreatedFaultConsumer>();
    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("auction", false));
  
    x.UsingRabbitMq((context, cfg) => 
    {
        cfg.ConfigureEndpoints(context);
    });
});


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
