using Registration.BusinessLayer.DTO;

namespace RegistrationBL.Interface
{
    public interface IRegistrationBusinessLayerService
    {
        Task<bool> Create(RegistrationDA.Entities.Registration registration);

        Task<bool> Remove(int id);

        Task<bool> Update(RegistrationDA.Entities.Registration registration);

        Task<ICollection<RegistrationDTO>> GetAll();

        Task<RegistrationDTO> RegistrationGetById(int id);

        Task<ICollection<RegistrationDTO>> SearchRegistration(string value);
    }
}
