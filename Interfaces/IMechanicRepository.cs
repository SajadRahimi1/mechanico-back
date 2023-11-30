using mechanico.Context;
using Microsoft.AspNetCore.Mvc;

namespace mechanico.Interfaces;

public interface IMechanicRepository
{
    public Task<ResultData> GetAll(int page=1);
}