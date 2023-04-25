using Microsoft.EntityFrameworkCore;
using FormulaApi.Models;
namespace FormulaApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base (options)
        {

        }
    }
}
