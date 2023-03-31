using RegistrationDA.Entities;

namespace RegistrationDA.Interface
{
    public interface IRegistrationDataAccessService
    {
        Task<bool> Create(Entities.Registration registration);

        Task<bool> Remove(int id);

        Task<bool> Update(Entities.Registration registration);

        Task<ICollection<Entities.Registration>> GetAll();

        Task<Entities.Registration> RegistrationGetById(int id);

        Task<ICollection<Entities.Registration>> SearchRegistration(string value);
    }
}
