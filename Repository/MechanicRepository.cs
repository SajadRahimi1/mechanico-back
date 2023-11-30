using mechanico.Context;
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

    public Task<ResultData> GetByCity()
    {
        throw new NotImplementedException();
    }
}