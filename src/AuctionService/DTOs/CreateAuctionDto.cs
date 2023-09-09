using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTOs
{
    /*
    * This class is used to transfer data from the client to the database
    Property Name Property Type Default Value
    Put Required Attribute on all properties
    Make string
    Model string)
    Color string
    Mileage int
    Year int
    ReservedPrice int
    ImageUrl string
    AuctionEnd DateTime 
    */
    public class CreateAuctionDto
    {
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Mileage { get; set; } = 0;
        public int Year { get; set; } = 0;
        [Required]
        public int ReservedPrice { get; set; } = 0;
        public string ImageUrl { get; set; }
        public string Seller { get; set; }
        [Required]
        public DateTime AuctionEnd { get; set; }
    }
}