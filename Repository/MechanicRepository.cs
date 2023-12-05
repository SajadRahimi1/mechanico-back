using AutoMapper;
using GeoCoordinatePortable;
using mechanico.Context;
using mechanico.Dtos;
using mechanico.Entities;
using mechanico.Interfaces;
using Microsoft.EntityFrameworkCore;


public class MechanicRepository : IMechanicRepository
{
    private readonly AppDbContext appDbContext;
    private readonly IMapper mapper;
    

    public MechanicRepository(AppDbContext appDbContext,IMapper mapper)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
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
        var mechanic = await appDbContext.Mechanics.Include(Mechanic=>Mechanic.Address).SingleOrDefaultAsync(mechanic1 => mechanic1.Id == id);
        mechanic.Address.Mechanic = null;
        return new ResultData(new Data { data = mechanic });
    }

    public async Task<ResultData> Search(SearchDto dto)
    {
        GeoCoordinate coordinate = new GeoCoordinate(dto.latitude,dto.longitude);
        List<SearchReturn> data = new List<SearchReturn>();
        var mechanics = await appDbContext.Mechanics.Include(mechanic => mechanic.Categories)
            .Include(mechanic => mechanic.Address).
            Where(mechanic => mechanic.Categories.Any(category => category.Title.Contains(dto.pattern))).ToListAsync();
        foreach (var mechanic in mechanics)
        {
            data.Add(new SearchReturn
            {
                Mechanic = mechanic,
                Distance = coordinate.GetDistanceTo(new GeoCoordinate(mechanic.Address.Latitude,
                    mechanic.Address.Longitude))
            });
        }

        return new ResultData(new Data { data = data });
    }

    public async Task<ResultData> Signup(Mechanic mechanic)
    {
        var savedMechanic = await appDbContext.Mechanics.AddAsync(mechanic);
        await appDbContext.SaveChangesAsync();
        return new ResultData(new Data { data = savedMechanic.Entity });
    }

    public async Task<ResultData> EditMechanicAddress(EditAddressDto addressDto)
    {
        var mechanic = await appDbContext.Mechanics.Include(Mechanic =>Mechanic.Address ).SingleOrDefaultAsync(_ => _.Id == addressDto.MechanicId);
        if (mechanic is null)
        {
            return new ResultData(new Data { statusCodes = 404, Message = "مکانیک یافت نشد" });
        }

        var address = mechanic.Address;
        if (address is null)
        {
            address = mapper.Map<Address>(addressDto);
            await appDbContext.Addresses.AddAsync(address);
        }
        else
        {
            address = mapper.Map<Address>(addressDto);
            appDbContext.Addresses.Update(address);
        }

        mechanic.Address = address;
        appDbContext.Mechanics.Update(mechanic);
        await appDbContext.SaveChangesAsync();
        return new ResultData(new Data { data = "ادیت شد" });
    }
}