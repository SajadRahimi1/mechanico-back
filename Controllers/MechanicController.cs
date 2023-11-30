using mechanico.Context;
using mechanico.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mechanico.Controllers;

[ApiController]
[Route("[controller]")]
public class MechanicController : ControllerBase
{
    private readonly IMechanicRepository mechanicRepository;

    public MechanicController(IMechanicRepository mechanicRepository)
    {
        this.mechanicRepository = mechanicRepository;
    }

    [HttpGet, Route("all")]
    public async Task<ResultData> GetAll([FromQuery] int page = 1)
    {
        return await mechanicRepository.GetAll(page);
    }
}