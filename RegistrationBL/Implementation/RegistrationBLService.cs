using AutoMapper;
using Registration.BusinessLayer.DTO;
using RegistrationBL.Interface;
using RegistrationDA.Interface;

namespace RegistrationBL.Implementation
{
    public class RegistrationBusinessLayerService : IRegistrationBusinessLayerService
    {
        private readonly IRegistrationDataAccessService _registration;
        private readonly IMapper _mapper;

        public RegistrationBusinessLayerService(IRegistrationDataAccessService registration, IMapper mapper)
        {
            _registration = registration;
            _mapper = mapper;
        }

        public async Task<bool> Create(RegistrationDA.Entities.Registration registration) => await _registration.Create(registration);

        public async Task<ICollection<RegistrationDTO>> GetAll() => _mapper.Map<ICollection<RegistrationDTO>>(await _registration.GetAll());

        public async Task<RegistrationDTO> RegistrationGetById(int id) => _mapper.Map<RegistrationDTO>(await _registration.RegistrationGetById(id));

        public async Task<bool> Remove(int id) => await _registration.Remove(id);

        public async Task<ICollection<RegistrationDTO>> SearchRegistration(string value) => _mapper.Map<ICollection<RegistrationDTO>>(await _registration.SearchRegistration(value));

        public async Task<bool> Update(RegistrationDA.Entities.Registration registration) => await _registration.Update(registration);
    }
}
