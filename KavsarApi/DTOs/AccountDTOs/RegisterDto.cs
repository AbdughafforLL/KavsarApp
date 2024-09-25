namespace KavsarApi.DTOs.AccountDTOs;
public class RegisterDto
{
    [MaxLength(100),Required(ErrorMessage = "Обязательно заполняйте имя пользователь")]
    public string UserName { get; set; } = null!;
    [MaxLength(100),DataType(DataType.Password)]
    public string Password { get; set; }=null!;
    [MaxLength(100),Compare("Password"),Required(ErrorMessage = "Обязательно заполняйте пароль")]
    public string ConfirmPassword { get; set; }=null!;
    
    [Required(ErrorMessage = "Обязательно выберите роль пользователь")]
    public Roles Role { get; set; }
}