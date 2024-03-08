using AutoMapper;
using OG.CRUD.VUE.Application.Common.DTOs;
using OG.CRUD.VUE.Domain;

namespace OG.CRUD.VUE.Application.Common.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDTO, PersonDOM>().ReverseMap();
        }
    }
}
