using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.Services;

namespace SearchService.Data
{
    public class DbInitializer
    {
        
        public static async Task InitDb(WebApplication app) {
            await DB.InitAsync("SearchDb", MongoClientSettings
                    .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

            // Create a text index on the Make, Model, and Color fields 
            // of the Item collection.
            await DB.Index<Item>()
                    .Key(x => x.Make, KeyType.Text)
                    .Key(x => x.Model, KeyType.Text)
                    .Key(x => x.Color, KeyType.Text)
                    .CreateAsync();

            var count = await DB.CountAsync<Item>();

            using var scope = app.Services.CreateScope();
            var httpClient = scope.ServiceProvider.GetRequiredService<AuctionSvcHttpClient>();

            var items = await httpClient.GetItemsForSearchDb();

            Console.WriteLine(items.Count + " items returned from Auction Service");

            if (items.Count > 0) await DB.SaveAsync(items);
        }
    }
}