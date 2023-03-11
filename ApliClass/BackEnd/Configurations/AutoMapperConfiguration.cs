﻿using AutoMapper;
using BackEnd.DTOs;
using Entities;

namespace BackEnd.Configurations;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<Attendance, AttendanceDTO>().ReverseMap();
        CreateMap<Class, ClassDTO>().ReverseMap();
        CreateMap<Assessment, AssessmentDTO>().ReverseMap();
        CreateMap<Lesson, LessonDTO>().ReverseMap();
        CreateMap<Student, StudentDTO>().ReverseMap();
        CreateMap<AttendanceState, AttendanceStateDTO>().ReverseMap();
        CreateMap<TypesOfUser, TypesOfUserDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
    }
}