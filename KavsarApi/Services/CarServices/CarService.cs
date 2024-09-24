using KavsarApi.DTOs.CarDTOs;

namespace KavsarApi.Services.CarServices;
public class CarService(DataContext context,IMapper mapper) : ICarService
{
    public async Task<Response<string>> CreateCar(CreateCarDto model)
    {
        var car = new Car() { 
            CarId = Guid.NewGuid().ToString(),
            AuctionEndDate = model.AuctionEndDate,
            Color = model.Color,
            CurrentBid = model.CurrentBid,
            LicensePlate = model.LicensePlate,
            Make = model.Make,
            Model = model.Model,
            Year = model.Year,
            StartingBid = model.StartingBid
        };
        try
        {
            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();
            return new Response<string>(car.CarId);
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<bool>> DeleteCar(string carId)
    {
        var car = await context.Cars.FirstOrDefaultAsync(c => c.CarId.Equals(carId));
        if (car!.Equals(null)) return new Response<bool>(HttpStatusCode.BadRequest, "По таким ID не существует автомобилей.");
        try
        {
            context.Cars.Remove(car);
            await context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<GetCarDto>> GetCarById(string carId)
    {
        var car = await context.Cars.FirstOrDefaultAsync(c=>c.CarId.Equals(carId));
        if (car!.Equals(null)) return new Response<GetCarDto>(HttpStatusCode.BadRequest, "По таким ID не существует автомобилей.");
        var mapCar = mapper.Map<GetCarDto>(car);
        return new Response<GetCarDto>(mapCar);
    }

    public async Task<Response<List<GetCarDto>>> GetCars(CarFilterDto model)
    {
        var cars = await context.Cars.ToListAsync();
        var mapCars = mapper.Map<List<GetCarDto>>(cars);
        return new Response<List<GetCarDto>>(mapCars);
    }

    public async Task<Response<bool>> UpdateCar(UpdateCarDto model)
    {
       var car = await context.Cars.FirstOrDefaultAsync(c=>c.CarId.Equals(model.CarId));
       if (car == null) return new Response<bool>(HttpStatusCode.BadRequest, "По таким ID не существует автомобилей.");
        car.Year = model.Year;
        car.CurrentBid = model.CurrentBid;
        car.AuctionEndDate = model.AuctionEndDate;
        car.Color = model.Color;
        car.LicensePlate = model.LicensePlate;
        car.Make = model.Make;
        car.Model = model.Model;
        car.StartingBid = model.StartingBid;

        try
        {
            await context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}