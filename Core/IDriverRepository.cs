using FormulaApi.Models;

namespace FormulaApi.Core
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<Driver?> GetDriverNb(int driverNb);

    }
}
