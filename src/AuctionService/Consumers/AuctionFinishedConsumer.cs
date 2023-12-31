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
    public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
    {
        private readonly AuctionDbContext _context;

        public AuctionFinishedConsumer(AuctionDbContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            Console.WriteLine("--> Consuming Auction finished event");
            var auction = await _context.Auctions.FindAsync(context.Message.AuctionId);

            if(context.Message.ItemSold) {
                auction.Winner = context.Message.Winner;
            } 

            auction.Status =  auction.SoldAmount > auction.ReservedPrice ? Status.Finished : Status.ReserveNotMet;

            await _context.SaveChangesAsync();
        }
    }
}