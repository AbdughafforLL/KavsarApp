namespace KavsarApi.DTOs.AccountDTOs;
public class LoginDto
{
    [MaxLength(100),Required(ErrorMessage = "")]
    public string UserName { get; set; } = null!;
    [MaxLength(100),Required(ErrorMessage = "")]
    public string Password { get; set; } = null!;
}