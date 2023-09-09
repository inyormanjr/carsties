namespace AuctionService.DTOs
{
    /*
    Make? string
    Model? string)
    Color? string
    Mileage? int
    Year? int
    */
    public class UpdateAuctionDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; } = "";
        public int? Mileage { get; set; } = 0;
        public int? Year { get; set; } = 0;
    }
}