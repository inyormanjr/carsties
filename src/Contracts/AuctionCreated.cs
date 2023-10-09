using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
    public class AuctionCreated
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime AuctionEnd { get; set; }
        public string Seller { get; set; }
        public string Winner { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; } = 0;
        public string Color { get; set; }
        public int Mileage { get; set; } = 0;
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public int ReservedPrice { get; set; } = 0;
        public int? SoldAmount { get; set; } = 0;
        public int? CurrentHighBid { get; set; } = 0;
    }
}