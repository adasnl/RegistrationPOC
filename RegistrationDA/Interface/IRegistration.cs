using RegistrationDA.Entities;

namespace RegistrationDA.Interface
{
    public interface IRegistration
    {
        Task<bool> Create(Registration registration);

        Task<bool> Remove(int id);

        Task<bool> Update(Registration registration);

        Task<List<Registration>> GetAll();

        Task<Registration> RegistrationGetById(int id);

        Task<List<Registration>> SearchRegistration(string value);
    }
}
