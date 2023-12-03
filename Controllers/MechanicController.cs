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
    public async Task<ResultData> GetAll([FromQuery] int page = 1) => await mechanicRepository.GetAll(page);


    [HttpGet, Route("city")]
    public async Task<ResultData> GetByCity([FromQuery] string city) => await mechanicRepository.GetByCity(city);


    [HttpGet]
    public async Task<ResultData> GetById([FromQuery] Guid id) => await mechanicRepository.GetById(id);

    [HttpPost]
    public async Task<ResultData> SearchMechanic([FromBody] string pattern) => await mechanicRepository.Search(pattern);
}