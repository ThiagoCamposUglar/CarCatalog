using API.Data;
using API.Data.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
        }

        public void DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<List<Car>> GetCarListAsync()
        {
            return await _context.Cars
                .Include(x => x.Manufacturer)
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<List<Car>> GetCarListByManufacturerId(int id)
        {
            return await _context.Cars.Where(x => x.ManufacturerId == id).ToListAsync();
        }

        public async Task<List<Car>> GetCarListByCategoryId(int id)
        {
            return await _context.Cars.Where(x => x.CategoryId == id).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateCar(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
        }
    }
}
