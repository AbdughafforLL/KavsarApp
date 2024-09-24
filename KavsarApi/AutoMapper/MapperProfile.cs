using KavsarApi.DTOs.CarDTOs;

namespace KavsarApi.AutoMapper;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Car, GetCarDto>();
    }
}