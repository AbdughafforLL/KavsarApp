namespace KavsarApi.DTOs.AccountDTOs;
public class RegisterDto
{
    [MaxLength(100)]
    public string UserName { get; set; } = null!;
    [MaxLength(100),DataType(DataType.Password)]
    public string Password { get; set; }=null!;
    [MaxLength(100),Compare("Password")]
    public string ConfirmPassword { get; set; }=null!;
    public Roles Role { get; set; }
}