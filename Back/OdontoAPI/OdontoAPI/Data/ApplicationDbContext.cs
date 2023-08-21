using Microsoft.EntityFrameworkCore;
using OdontoAPI.Models;

namespace OdontoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PacienteModel> Pacientes { get; set; }
    }
}
