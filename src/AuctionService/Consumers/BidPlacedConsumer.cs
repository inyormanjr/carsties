using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionService.Data;
using AuctionService.Entities;
using Contracts;
using MassTransit;

namespace AuctionService.Consumers
{
    public class BidPlacedConsumer : IConsumer<BidPlaced>
    {
        private readonly AuctionDbContext _dbContext;
        public BidPlacedConsumer(AuctionDbContext dbContext)
        {
            this._dbContext = dbContext;
            
        }
        public async Task Consume(ConsumeContext<BidPlaced> context)
        {
            Console.WriteLine("--> Consuming bid placed event");
            
            var auction = await _dbContext.Auctions.FindAsync(context.Message.AuctionId);

            if(auction.CurrentHighBid == null || context.Message.BidStatus.Contains("Accepted") && context.Message.Amount > auction.CurrentHighBid)
            {
                auction.CurrentHighBid = context.Message.Amount;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}