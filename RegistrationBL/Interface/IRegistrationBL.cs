using RegistrationDA.Entities;

namespace RegistrationBL.Interface
{
    public interface IRegistrationBL
    {
        Task<bool> Create(Registration registration);

        Task<bool> Remove(int id);

        Task<bool> Update(Registration registration);

        Task<List<Registration>> GetAll();

        Task<Registration> RegistrationGetById(int id);

        Task<List<Registration>> SearchRegistration(string value);
    }
}
