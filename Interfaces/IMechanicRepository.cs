using mechanico.Context;
using mechanico.Dtos;
using mechanico.Entities;
using Microsoft.AspNetCore.Mvc;

namespace mechanico.Interfaces;

public interface IMechanicRepository
{
    public Task<ResultData> GetAll(int page=1);
    public Task<ResultData> GetByCity(string city);
    public Task<ResultData> GetById(Guid id);
    public Task<ResultData> Search(SearchDto dto);
    public Task<ResultData> Signup(Mechanic mechanic);

}