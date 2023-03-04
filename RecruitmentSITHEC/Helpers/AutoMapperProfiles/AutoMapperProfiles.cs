using AutoMapper;
using RecruitmentSITHEC.DTOs.Human;
using RecruitmentSITHEC.Entities;

namespace RecruitmentSITHEC.Helpers.AutoMapperProfiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<HumanCreateDTO, Human>().ReverseMap();
            CreateMap<Human, HumanListDTO>().ReverseMap(); 
        }
    }
}
