namespace RegistrationBL.Interface
{
    public interface IRegistrationBusinessLayerService
    {
        Task<bool> Create(RegistrationDA.Entities.Registration registration);

        Task<bool> Remove(int id);

        Task<bool> Update(RegistrationDA.Entities.Registration registration);

        Task<ICollection<RegistrationDA.Entities.Registration>> GetAll();

        Task<RegistrationDA.Entities.Registration> RegistrationGetById(int id);

        Task<ICollection<RegistrationDA.Entities.Registration>> SearchRegistration(string value);
    }
}
