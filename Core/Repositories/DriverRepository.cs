using FormulaApi.Data;
using FormulaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Core.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Driver>> All()
        {
            try
            {
                return _context.Drivers.Where(x => x.Id < 100).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
                
            }
        }

        public override async Task<Driver?> GetById(int id)
        {
            try
            {
                return await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Driver?> GetDriverNb(int driverNb)
        {
            try
            {
                return await _context.Drivers.FirstOrDefaultAsync(x => x.DriverNum == driverNb);

            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
