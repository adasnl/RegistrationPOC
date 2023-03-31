using RegistrationBL.Interface;
using RegistrationDA.Interface;

namespace RegistrationBL.Implementation
{
    public class RegistrationBusinessLayerService : IRegistrationBusinessLayerService
    {
        private readonly IRegistrationDataAccessService _registration;

        public RegistrationBusinessLayerService(IRegistrationDataAccessService registration)
        {
            _registration = registration;
        }

        public async Task<bool> Create(RegistrationDA.Entities.Registration registration) => await _registration.Create(registration);

        public async Task<ICollection<RegistrationDA.Entities.Registration>> GetAll() => await _registration.GetAll();

        public async Task<RegistrationDA.Entities.Registration> RegistrationGetById(int id) => await _registration.RegistrationGetById(id);

        public async Task<bool> Remove(int id) => await _registration.Remove(id);

        public async Task<ICollection<RegistrationDA.Entities.Registration>> SearchRegistration(string value) => await _registration.SearchRegistration(value);

        public async Task<bool> Update(RegistrationDA.Entities.Registration registration) => await _registration.Update(registration);
    }
}
