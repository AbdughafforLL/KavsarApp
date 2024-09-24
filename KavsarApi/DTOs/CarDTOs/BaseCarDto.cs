namespace KavsarApi.DTOs.CarDTOs;
public abstract class BaseCarDto
{
    [MaxLength(50) , Required(ErrorMessage = "Обязательно заполняйте производитель автомобиля.")]
    public string Make { get; set; } = null!;
    [MaxLength(50), Required(ErrorMessage = "Обязательно заполняйте модель автомобиля.")]
    public string Model { get; set; } = null!;
    [Required(ErrorMessage = "Обязательно заполняйте год выпуска автомобиля.")]
    public int Year { get; set; }
    [MaxLength(30), Required(ErrorMessage = "Обязательно заполняйте цвет автомобиля.")]
    public string Color { get; set; } = null!;
    [MaxLength(20), Required(ErrorMessage = "Обязательно заполняйте номерной знак.")]
    public string LicensePlate { get; set; } = null!;
    [Required(ErrorMessage = "")]
    public decimal CurrentBid { get; set; }
    [Required(ErrorMessage = "Обязательно заполняйте начальная ставка.")]
    public decimal StartingBid { get; set; }
    [Required(ErrorMessage = "Обязательно задайте дату окончания аукциона.")]
    public DateTime AuctionEndDate { get; set; }
}