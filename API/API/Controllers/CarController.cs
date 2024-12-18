using API.Data.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace API.Controllers
{
    public class CarController : BaseApiController
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);
            return Ok(car);
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCars()
        {
            var carList = await _carRepository.GetCarListAsync();
            return Ok(carList);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(Car car)
        {
            _carRepository.AddCar(car);

            if(await _carRepository.SaveAllAsync()) return Created(string.Empty, car);

            return BadRequest("Failed to create car");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCar(Car car)
        {
            var carToUpdate = await _carRepository.GetCarByIdAsync(car.Id);

            if (carToUpdate is null) return BadRequest("Car not found");

            carToUpdate.Model = car.Model;
            carToUpdate.MaxPower = car.MaxPower;
            carToUpdate.Length = car.Length;
            carToUpdate.Width = car.Width;
            carToUpdate.Height = car.Height;
            carToUpdate.Weight = car.Weight;
            carToUpdate.Description = car.Description;
            carToUpdate.ManufacturerId = car.ManufacturerId;
            carToUpdate.CategoryId = car.CategoryId;

            if (await _carRepository.SaveAllAsync())
                return Ok("Car successfully updated");

            return BadRequest("Problem while updating car");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCar(int id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);

            if (car is null) return BadRequest("Car not found");

            _carRepository.DeleteCar(car);

            if (await _carRepository.SaveAllAsync())
                return Ok("Car successfully deleted");

            return BadRequest("Problem deleting car");
        }
    }
}
