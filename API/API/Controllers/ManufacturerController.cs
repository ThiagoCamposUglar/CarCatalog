using API.Data.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ManufacturerController : BaseApiController
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly ICarRepository _carRepository;
        public ManufacturerController(IManufacturerRepository manufacturerRepository, ICarRepository carRepository)
        {
            _manufacturerRepository = manufacturerRepository;
            _carRepository = carRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturerById(int id)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(id);
            return Ok(manufacturer);
        }

        [HttpGet]
        public async Task<ActionResult<List<Manufacturer>>> GetManufacturers()
        {
            var manufacturerList = await _manufacturerRepository.GetManufacturerListAsync();
            return Ok(manufacturerList);
        }

        [HttpPost]
        public async Task<ActionResult<Manufacturer>> CreateManufacturer(Manufacturer manufacturer)
        {
            _manufacturerRepository.AddManufacturer(manufacturer);

            if (await _manufacturerRepository.SaveAllAsync()) return Created(string.Empty, manufacturer);

            return BadRequest("Failed to create manufacturer");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateManufacturer(Manufacturer manufacturer)
        {
            var mToUpdate = await _manufacturerRepository.GetManufacturerByIdAsync(manufacturer.Id);

            if (mToUpdate is null) return BadRequest("Manufacturer not found");

            mToUpdate.Name = manufacturer.Name;
            mToUpdate.Description = manufacturer.Description;

            if (await _manufacturerRepository.SaveAllAsync())
                return Ok("Manufacturer successfully updated");

            return BadRequest("Problem while updating Manufacturer");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteManufacturer(int id)
        {
            var car = await _manufacturerRepository.GetManufacturerByIdAsync(id);

            if (car is null) return BadRequest("Manufacturer not found");

            var carList = await _manufacturerRepository.GetManufacturerListAsync();

            if (carList.Any())
                return BadRequest("This manufacturer cannot be deleted because there are cars associated with it. Please remove or reassign the associated cars before attempting to delete the manufacturer");

            _manufacturerRepository.DeleteManufacturer(car);

            if (await _manufacturerRepository.SaveAllAsync())
                return Ok("Manufacturer successfully deleted");

            return BadRequest("Problem deleting manufacturer");
        }
    }
}
