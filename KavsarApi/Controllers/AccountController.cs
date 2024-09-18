using KavsarApi.DTOs.AccountDTOs;
using KavsarApi.Enums;
using KavsarApi.Services.AccountServices;
namespace KavsarApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles="User")]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var res = await accountService.Login(model);
        return StatusCode(res.StatusCode, res);
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        var res = await accountService.Register(model);
        return StatusCode(res.StatusCode, res);
    }
    [HttpGet("GetRoles")]
    public IActionResult GetRoles()
    {
        var roles = Enum.GetValues(typeof(Roles)).Cast<Roles>().Select(v => v.ToString()).ToList(); ;
        return Ok(roles);
    }
}