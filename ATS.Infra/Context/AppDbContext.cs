using ATS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ATS.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Proprietario> Proprietario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
    }
}