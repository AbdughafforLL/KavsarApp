namespace KavsarApi.Entites;
public class Car
{
    [MaxLength(100), Key]
    public string CarId { get; set; } = null!;
    [MaxLength(50)]
    public string Make { get; set; } = null!;
    [MaxLength(50)]
    public string Model { get; set; } = null!;
    public int Year { get; set; }
    [MaxLength(30)]
    public string Color { get; set; } = null!;
    [MaxLength(20)]
    public string LicensePlate { get; set; } = null!;
    public decimal CurrentBid { get; set; }
    public decimal StartingBid { get; set; }
    public DateTime AuctionEndDate { get; set; }
    public List<Bid> Bids { get; set; } = null!;
}