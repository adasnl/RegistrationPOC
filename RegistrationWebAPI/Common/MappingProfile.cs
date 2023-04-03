using AutoMapper;
using Registration.BusinessLayer.DTO;

namespace RegistrationWebAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationDA.Entities.Registration, RegistrationDTO>();
        }
    }
}
