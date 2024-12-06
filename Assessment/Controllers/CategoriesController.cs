using Assessment.DTOs.Get;
using Assessment.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpPost]
        public IActionResult PostCategory(CategoryDTO categoryDTO)
        {
            try
            {
                _categoryRepository.AddCategory(categoryDTO);
                return Created();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, CategoryDTO categoryDTO)
        {
            try
            {
                _categoryRepository.UpdateCategory(id, categoryDTO);
                return Ok();
            }catch (NullReferenceException)
            {
                return NotFound("Not Found Category");
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

        }
    }

}
