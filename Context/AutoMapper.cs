using AutoMapper;
using mechanico.Dtos;
using mechanico.Entities;

namespace mechanico.Context;

public class AutoMapper:Profile
{
    public AutoMapper()
    {
        CreateMap<CreateMechanicDto, Mechanic>();
        CreateMap<EditAddressDto, Address>();
    }
}