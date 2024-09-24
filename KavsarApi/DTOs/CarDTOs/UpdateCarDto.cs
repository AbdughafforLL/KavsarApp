namespace KavsarApi.DTOs.CarDTOs;
public class UpdateCarDto : BaseCarDto
{
    [MaxLength(100), Required(ErrorMessage = "Обязательно заполняйте yникальный идентификатор автомобиля.")]
    public string CarId { get; set; } = null!;
}