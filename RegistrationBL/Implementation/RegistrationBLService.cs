using RegistrationBL.Interface;
using RegistrationDA.Entities;
using RegistrationDA.Interface;

namespace RegistrationBL.Implementation
{
    public class RegistrationBLService : IRegistrationBL
    {
        private readonly IRegistration _registration;

        public RegistrationBLService(IRegistration registration)
        {
            _registration = registration;
        }

        public async Task<bool> Create(Registration registration) => await _registration.Create(registration);

        public async Task<List<Registration>> GetAll() => await _registration.GetAll();

        public async Task<Registration> RegistrationGetById(int id) => await _registration.RegistrationGetById(id);

        public async Task<bool> Remove(int id) => await _registration.Remove(id);

        public async Task<List<Registration>> SearchRegistration(string value) => await _registration.SearchRegistration(value);

        public async Task<bool> Update(Registration registration) => await _registration.Update(registration);
    }
}
