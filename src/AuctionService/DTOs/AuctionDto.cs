namespace AuctionService.DTOs
{

    /*
    * This class is used to transfer data from the database to the client
    Property Name Property Type Default Value
    Id Guid
    CreatedAt DateTime
    UpdatedAt DateTime
    AuctionEnd DateTime
    Seller string
    Winner string
    Make string
    Model string)
    Year int
    Color string
    Mileage int
    ImageUrl string
    Status string
    ReservedPrice int
    SoldAmount? int
    CurrentHighBid? int
    */

    public class AuctionDto
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