using API.Data;
using API.Data.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly DataContext _context;

        public ManufacturerRepository(DataContext context)
        {
            _context = context;
        }

        public void AddManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
        }

        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturers.Remove(manufacturer);
        }

        public async Task<Manufacturer> GetManufacturerByIdAsync(int id)
        {
            return await _context.Manufacturers.FindAsync(id);
        }

        public async Task<List<Manufacturer>> GetManufacturerListAsync()
        {
            return await _context.Manufacturers.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            _context.Entry(manufacturer).State = EntityState.Modified;
        }
    }
}
