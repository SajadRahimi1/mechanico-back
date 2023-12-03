using mechanico.Context;
using Microsoft.AspNetCore.Mvc;

namespace mechanico.Interfaces;

public interface IMechanicRepository
{
    public Task<ResultData> GetAll(int page=1);
    public Task<ResultData> GetByCity(string city);
    public Task<ResultData> GetById(Guid id);

}