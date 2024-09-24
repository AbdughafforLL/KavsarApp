namespace KavsarApi.Entites;
public class Bid
{
    [MaxLength(100), Key]
    public string BidId { get; set; } = null!;
    [MaxLength(100)]
    public string CarId { get; set; } = null!;
    public Car Car { get; set; } = null!;
    [MaxLength(100)]
    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
    public decimal BidAmount { get; set; }
    public DateTime BidDate { get; set; }
    public Payment? Payment { get; set; }
}