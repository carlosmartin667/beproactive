using ApiDevBP.Entities;
using ApiDevBP.Models;
using AutoMapper;

namespace ApiDevBP.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           // CreateMap<UserModel, UserEntity>().ReverseMap();
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
