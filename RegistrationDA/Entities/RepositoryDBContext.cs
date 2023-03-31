using Microsoft.EntityFrameworkCore;

namespace RegistrationDA.Entities
{
    public class RepositoryDBContext : DbContext
    {
        public DbSet<Registration> Registrations { get; set; }
        public string DatabasePath { get; private set; }
        public RepositoryDBContext()
        {
            DatabasePath = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}Registration.sqlite";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DatabasePath}");
            options.LogTo(Console.WriteLine);
        }
    }
}
