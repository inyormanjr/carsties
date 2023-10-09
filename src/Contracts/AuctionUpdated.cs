using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
    public class AuctionUpdated
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; } = "";
        public int Mileage { get; set; } = 0;
        public int Year { get; set; } = 0;
    }
}