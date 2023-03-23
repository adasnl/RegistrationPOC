using Microsoft.EntityFrameworkCore;
using RegistrationDA.Entities;
using RegistrationDA.Interface;

namespace RegistrationDA.Implementation
{
    public class RegistrationService : IRegistration
    {
        public RegistrationService()
        {
            using (var context = new RegistrationDBContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public async Task<bool> Create(Registration registration)
        {
            try
            {
                registration.RegisteredDate = DateTime.Now;
                registration.ModifiedDate = DateTime.Now;
                using (var context = new RegistrationDBContext())
                {
                    context.Registrations.Add(registration);
                    var entries = await context.SaveChangesAsync();
                    return entries > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Registration>> GetAll()
        {
            try
            {
                using (var context = new RegistrationDBContext())
                {
                    var result = await context.Registrations.ToListAsync();
                    result = result.OrderByDescending(_ => _.ModifiedDate).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Registration> RegistrationGetById(int id)
        {
            try
            {
                using (var context = new RegistrationDBContext())
                {
                    return await context.Registrations.Where(_ => _.Id == id).Select(_ => _).FirstAsync();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                using (var context = new RegistrationDBContext())
                {
                    var registration = await context.Registrations.Where(_ => _.Id.Equals(id)).FirstAsync();
                    context.Registrations.Remove(registration);
                    var entries = context.SaveChanges();
                    return entries > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Registration>> SearchRegistration(string value)
        {
            try
            {
                using (var context = new RegistrationDBContext())
                {
                    var registrations = await context.Registrations.ToListAsync();
                    if (string.IsNullOrWhiteSpace(value))
                        return registrations;
                    else
                    {
                        var result = registrations.Where(_ => _.Name.Contains(value, StringComparison.OrdinalIgnoreCase)
                        || _.Email.Contains(value, StringComparison.OrdinalIgnoreCase)
                        || _.City.Contains(value, StringComparison.OrdinalIgnoreCase)).Select(_ => _).ToList();
                        return result;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> Update(Registration newRegistration)
        {
            try
            {
                using (var context = new RegistrationDBContext())
                {
                    var registration = await context.Registrations.FindAsync(newRegistration.Id);

                    if (registration != null)
                    {
                        registration.PinCode = newRegistration.PinCode;
                        registration.RegisteredDate = newRegistration.RegisteredDate;
                        registration.PhoneNumber = newRegistration.PhoneNumber;
                        registration.Email = newRegistration.Email;
                        registration.City = newRegistration.City;
                        registration.Name = newRegistration.Name;
                        registration.ModifiedDate = DateTime.Now;
                    }
                    var entries = context.SaveChanges();
                    return entries > 0 ? true : false;
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
