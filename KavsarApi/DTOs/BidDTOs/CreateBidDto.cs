namespace KavsarApi.DTOs.BidDTOs;
public class CreateBidDto
{
    [MaxLength(100),Required(ErrorMessage = "Обязательно заполняйте уникальный идентификатор ставки.")]
    public string BidId { get; set; } = null!;
}