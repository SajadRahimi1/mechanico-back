using GeoCoordinatePortable;
using mechanico.Context;
using mechanico.Dtos;
using mechanico.Interfaces;
using Microsoft.EntityFrameworkCore;


public class MechanicRepository : IMechanicRepository
{
    private readonly AppDbContext appDbContext;

    public MechanicRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<ResultData> GetAll(int page = 1)
    {
        var mechanics = await appDbContext.Mechanics.Skip((page - 1) * 25).Take(25).ToListAsync();
        return new ResultData(new Data { data = mechanics });
    }

    public async Task<ResultData> GetByCity(string city)
    {
        var mechanics = await appDbContext.Mechanics.Where(mechanic => mechanic.Address.City == city).ToListAsync();
        return new ResultData(new Data { data = mechanics });
    }

    public async Task<ResultData> GetById(Guid id)
    {
        var mechanic = await appDbContext.Mechanics.SingleOrDefaultAsync(mechanic1 => mechanic1.Id == id);
        return new ResultData(new Data { data = mechanic });
    }

    public async Task<ResultData> Search(SearchDto dto)
    {
        GeoCoordinate coordinate = new GeoCoordinate(dto.latitude,dto.longitude);
        List<SearchReturn> data = new List<SearchReturn>();
        var mechanics = await appDbContext.Mechanics.Include(mechanic => mechanic.Categories)
            .Include(mechanic => mechanic.Address).
            Where(mechanic => mechanic.Categories.Any(category => category.Title.Contains(dto.pattern))).ToListAsync();
        mechanics.Select(mechanic => data.Append(new SearchReturn
        {
            Mechanic = mechanic,
            Distance = coordinate.GetDistanceTo(new GeoCoordinate(mechanic.Address.Latitude,mechanic.Address.Longitude))
        }));
        
        return new ResultData(new Data { data = data });
    }
}