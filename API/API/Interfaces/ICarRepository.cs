using API.Data.Entities;

namespace API.Interfaces
{
    public interface ICarRepository
    {
        Task<Car> GetCarByIdAsync(int id);
        Task<List<Car>> GetCarListAsync();
        Task<List<Car>> GetCarListByManufacturerId(int id);
        Task<bool> SaveAllAsync();
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
    }
}
