namespace KavsarApi.DTOs.BidDTOs;
public abstract class BaseBidDto
{
    [MaxLength(100),Required(ErrorMessage = "Обязательно заполняйте уникальный идентификатор автомобиля.")]
    public string CarId { get; set; } = null!;
    [MaxLength(100),Required(ErrorMessage = "Обязательно заполняйте уникальный идентификатор пользователь.")]
    public string UserId { get; set; } = null!;
    [Required(ErrorMessage = "Обязательно заполняйте сумму ставки.")]
    public decimal BidAmount { get; set; }
    [DataType(DataType.DateTime),Required(ErrorMessage = "Обязательно зададите дата и время размещения ставки.")]
    public DateTime BidDate { get; set; }
}