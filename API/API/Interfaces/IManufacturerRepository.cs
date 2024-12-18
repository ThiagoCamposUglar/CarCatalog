using API.Data.Entities;

namespace API.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> GetManufacturerByIdAsync(int id);
        Task<List<Manufacturer>> GetManufacturerListAsync();
        Task<bool> SaveAllAsync();
        void AddManufacturer(Manufacturer manufacturer);
        void UpdateManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(Manufacturer manufacturer);
    }
}
