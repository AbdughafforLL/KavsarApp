namespace KavsarApi.DTOs.BidDTOs;
public class GetBidDto
{
    [MaxLength(100), Required(ErrorMessage = "Обязательно заполняйте уникальный идентификатор ставки.")]
    public string BidId { get; set; } = null!;
    public User User { get; set; } = null!;
    public Payment? Payment { get; set; }
}