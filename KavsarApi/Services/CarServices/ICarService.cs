using KavsarApi.DTOs.CarDTOs;

namespace KavsarApi.Services.CarServices;
public interface ICarService
{
    Task<Response<string>> CreateCar(CreateCarDto model);
    Task<Response<bool>> DeleteCar(string carId);
    Task<Response<bool>> UpdateCar(UpdateCarDto model);
    Task<Response<GetCarDto>> GetCarById(string carId);
    Task<Response<List<GetCarDto>>> GetCars(CarFilterDto model);
}