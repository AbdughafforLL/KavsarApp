using KavsarApi.DTOs.BidDTOs;
namespace KavsarApi.Services.BidServices;
public interface IBidService
{
    Task<Response<string>> CreateBid(CreateBidDto model);
    Task<Response<string>> UpdateBid(UpdateBidDto model);
    Task<Response<bool>> DeleteBid(string bidId);
    Task<Response<GetBidDto>> GetBidById(string bidId);
    Task<Response<List<GetBidDto>>> GetBidById(BidFilterDto model);
}
