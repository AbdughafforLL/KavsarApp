using KavsarApi.DTOs.BidDTOs;
namespace KavsarApi.Services.BidServices;

public class BidService(DataContext context) : IBidService
{
    public async Task<Response<string>> CreateBid(CreateBidDto model)
    {
        var bid = await context.Bids.FirstOrDefaultAsync(b=>b.CarId.Equals(model.CarId));
        if (bid != null) return new Response<string>(HttpStatusCode.BadRequest, "Эта машина уже участвует в аукционе.");
        var bidEntity = new Bid()
        {
            BidId = Guid.NewGuid().ToString(),
            CarId = model.CarId,
            BidAmount = model.BidAmount,
            BidDate = model.BidDate,
            UserId = model.UserId,
        };
        try
        {
            await context.Bids.AddAsync(bidEntity);
            await context.SaveChangesAsync();
            return new Response<string>(bidEntity.BidId);
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<bool>> DeleteBid(string bidId)
    {
        var bid = await context.Bids.FirstOrDefaultAsync(b => b.BidId.Equals(bidId));
        if (bid == null) return new Response<bool>(HttpStatusCode.BadRequest, "Аукцион с таким ID не существует.");
        try
        {
            context.Bids.Remove(bid);
            await context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<GetBidDto>> GetBidById(string bidId)
    {
        var bid = await context.Bids.Select(b=>new GetBidDto() { 
            BidAmount = b.BidAmount,
            BidDate = b.BidDate,
            BidId = b.BidId,
            CarId = b.CarId,
            Payment = b.Payment,
            User = b.User
        }).FirstOrDefaultAsync(b=>b.BidId.Equals(bidId));
        if (bid == null) return new Response<GetBidDto>(HttpStatusCode.BadRequest, "Аукцион с таким ID не существует.");
        return new Response<GetBidDto>(bid);
    }

    public async Task<Response<List<GetBidDto>>> GetBids(BidFilterDto model)
    {
        var bids = await context.Bids.Select(b => new GetBidDto()
        {
            BidAmount = b.BidAmount,
            BidDate = b.BidDate,
            BidId = b.BidId,
            CarId = b.CarId,
            User = b.User
        }).ToListAsync();
        return new Response<List<GetBidDto>>(bids);
    }

    public Task<Response<string>> UpdateBid(UpdateBidDto model)
    {
        throw new NotImplementedException();
    }
}
