namespace KavsarApi.Entites;
public class Payment
{
    [MaxLength(100), Key]
    public string PaymentId { get; set; } = null!;
    [MaxLength(100)]
    public string BidId { get; set; } = null!;
    public Bid Bid { get; set; } = null!;
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethods PaymentMethod { get; set; }
}