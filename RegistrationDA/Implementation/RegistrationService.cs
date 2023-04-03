using Microsoft.EntityFrameworkCore;
using Registration.DataAccess.Implementation;
using RegistrationDA.Entities;
using RegistrationDA.Interface;

namespace RegistrationDA.Implementation
{
    public class RegistrationService : RepositoryBase<Entities.Registration>, IRegistrationDataAccessService
    {
        public RegistrationService(RepositoryDBContext dbContext) : base(dbContext) { }

        public async Task<bool> Create(Entities.Registration registration)
        {
            registration.RegisteredDate = DateTime.Now;
            registration.ModifiedDate = DateTime.Now;
            var entries = await CreateEntity(registration);
            return entries;
        }

        public async Task<ICollection<Entities.Registration>> GetAll()
        {
            var result = await GetAllEntities();
            result = result.OrderByDescending(_ => _.ModifiedDate);
            return result.ToList();
        }

        public async Task<Entities.Registration> RegistrationGetById(int id)
        {
            var result = await FindByCondition(_ => _.Id.Equals(id));
            return result.First();
        }

        public async Task<bool> Remove(int id)
        {
            var entries = await DeleteEntity(id);
            return entries;
        }

        public async Task<ICollection<Entities.Registration>> SearchRegistration(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var result = await FindByCondition(_ => _.Name.Contains(value, StringComparison.OrdinalIgnoreCase)
                || _.Email.Contains(value, StringComparison.OrdinalIgnoreCase)
                || _.City.Contains(value, StringComparison.OrdinalIgnoreCase));
                return result.ToList();
            }
            else
                return new List<Entities.Registration>();
        }

        public async Task<bool> Update(Entities.Registration newRegistration)
        {
            var entries = await UpdateEntity(newRegistration);
            return entries;
        }
    }
}
