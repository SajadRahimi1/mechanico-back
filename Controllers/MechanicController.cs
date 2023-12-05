using AutoMapper;
using mechanico.Context;
using mechanico.Dtos;
using mechanico.Entities;
using mechanico.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mechanico.Controllers;

[ApiController]
[Route("[controller]")]
public class MechanicController : ControllerBase
{
    private readonly IMechanicRepository mechanicRepository;
    private readonly IMapper Mapper;

    public MechanicController(IMechanicRepository mechanicRepository,IMapper Mapper)
    {
        this.mechanicRepository = mechanicRepository;
        this.Mapper = Mapper;
    }

    [HttpGet, Route("all")]
    public async Task<ResultData> GetAll([FromQuery] int page = 1) => await mechanicRepository.GetAll(page);


    [HttpGet, Route("city")]
    public async Task<ResultData> GetByCity([FromQuery] string city) => await mechanicRepository.GetByCity(city);


    [HttpGet]
    public async Task<ResultData> GetById([FromQuery] Guid id) => await mechanicRepository.GetById(id);

    [HttpPost,Route("search")]
    public async Task<ResultData> SearchMechanic([FromBody] SearchDto searchDto) => await mechanicRepository.Search(searchDto);

    [HttpPost, Route("signup")]
    public async Task<ResultData> SignupMechanic([FromBody] CreateMechanicDto dto)
    {
        var mechanic = Mapper.Map<Mechanic>(dto);
        return await mechanicRepository.Signup(mechanic);
    }
}