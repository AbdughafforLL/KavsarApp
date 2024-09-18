using KavsarApi.DTOs.AccountDTOs;
using KavsarApi.Enums;

namespace KavsarApi.Services.AccountServices;
public class AccountService(DataContext context,IConfiguration configuration) : IAccountService
{
    public async Task<Response<string>> Login(LoginDto model)
    {
        var user = await context.Users.FirstOrDefaultAsync(u=>u.UserName==model.UserName);
        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.HashPassword))
            return new Response<string>(HttpStatusCode.BadRequest,"Логин или пароль не правильно");
        var token = await JwtHelpers.GenerateJwtToken(user,configuration);
        return new Response<string>(token);
    }

    public async Task<Response<bool>> Register(RegisterDto model)
    {
        var user = await context.Users.FirstOrDefaultAsync(u=>u.UserName == model.UserName);
        if (user != null) return new Response<bool>(HttpStatusCode.BadRequest, "Пользователь с таким именем уже существует.");
        user = new User() { 
            UserId = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.Now,
            HashPassword = BCrypt.Net.BCrypt.HashPassword(model.Password),
            Role = Roles.User.ToString(),
            UserName = model.UserName
        };
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return new Response<bool>(true);
    }
}