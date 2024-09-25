using KavsarApi.DTOs.CarDTOs;
using KavsarApi.Services.CarServices;
namespace KavsarApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController(ICarService carService) : ControllerBase
{
    [HttpPost("CreateCar")]
    [Authorize(Roles = "Buyer")]
    public async Task<IActionResult> CreateCar(CreateCarDto model) {
        if (!ModelState.IsValid) {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            var resErr = new Response<string>(HttpStatusCode.BadRequest, errors);
            return BadRequest(resErr);
        }
        var res = await carService.CreateCar(model);
        return StatusCode(res.StatusCode,res);
    }

    [HttpPut("UpdateCar")]
    [Authorize(Roles = "Buyer")]
    public async Task<IActionResult> UpdateCar(UpdateCarDto model)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            var resErr = new Response<string>(HttpStatusCode.BadRequest, errors);
            return BadRequest(resErr);
        }
        var res = await carService.UpdateCar(model);
        return StatusCode(res.StatusCode, res);
    }
    [HttpDelete("DeleteCar")]
    [Authorize(Roles = "Buyer")]
    public async Task<IActionResult> DeleteCar(string carId)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            var resErr = new Response<string>(HttpStatusCode.BadRequest, errors);
            return BadRequest(resErr);
        }
        var res = await carService.DeleteCar(carId);
        return StatusCode(res.StatusCode, res);
    }
    [HttpPost("GetCarById")]
    [Authorize(Roles = "Buyer,Seller")]
    public async Task<IActionResult> GetCarById(string carId)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            var resErr = new Response<string>(HttpStatusCode.BadRequest, errors);
            return BadRequest(resErr);
        }
        var res = await carService.GetCarById(carId);
        return StatusCode(res.StatusCode, res);
    }
    [HttpPost("GetCars")]
    [Authorize(Roles = "Buyer,Seller")]
    public async Task<IActionResult> GetCars(CarFilterDto model)
    {
        var res = await carService.GetCars(model);
        return StatusCode(res.StatusCode, res);
    }
}