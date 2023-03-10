using AutoMapper;
using BackEnd.DTOs;
using Entities;

namespace BackEnd.Configurations;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<User, UsuarioDTO>().ReverseMap();
        CreateMap<Attendance, AsistenciaDTO>().ReverseMap();
    }
}