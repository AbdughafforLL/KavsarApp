using KavsarApi.DTOs.AccountDTOs;

namespace KavsarApi.Services.AccountServices;
public interface IAccountService
{
    Task<Response<string>> Login(LoginDto model); 
    Task<Response<bool>> Register(RegisterDto model); 
}