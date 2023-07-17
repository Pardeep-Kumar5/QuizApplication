using AutoMapper;
using QuizApplicationBackend.MappingProfile.DTOs;
using QuizApplicationBackend.Model;
using QuizApplicationBackend.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplicationBackend.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, RegisterTable>().ReverseMap();
            CreateMap<LoginDto, LoginVM>().ReverseMap();
        }
    }
}
