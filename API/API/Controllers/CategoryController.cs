using API.Data.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICarRepository _carRepository;

        public CategoryController(ICategoryRepository categoryRepository, ICarRepository carRepository)
        {
            _categoryRepository = categoryRepository;
            _carRepository = carRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategorys()
        {
            var categoryList = await _categoryRepository.GetCategoryListAsync();
            return Ok(categoryList);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            _categoryRepository.AddCategory(category);

            if (await _categoryRepository.SaveAllAsync()) return Created(string.Empty, category);

            return BadRequest("Failed to create category");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(Category category)
        {
            var mToUpdate = await _categoryRepository.GetCategoryByIdAsync(category.Id);

            if (mToUpdate is null) return BadRequest("Category not found");

            mToUpdate.Name = category.Name;

            if (await _categoryRepository.SaveAllAsync())
                return Ok("Category successfully updated");

            return BadRequest("Problem while updating Category");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var car = await _categoryRepository.GetCategoryByIdAsync(id);
            if (car is null) return BadRequest("Category not found");

            var carList = await _categoryRepository.GetCategoryListAsync();

            if (carList.Any())
                return BadRequest("This category cannot be deleted because there are cars associated with it. Please remove or reassign the associated cars before attempting to delete the category");

            _categoryRepository.DeleteCategory(car);

            if (await _categoryRepository.SaveAllAsync())
                return Ok("Category successfully deleted");

            return BadRequest("Problem deleting category");
        }
    }
}
