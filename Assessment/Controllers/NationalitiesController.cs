using Assessment.DTOs.Get;
using Assessment.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : ControllerBase
    {
        private readonly INationalityRepository _nationalityRepository;

        public NationalitiesController(INationalityRepository nationalityRepository)
        {
            _nationalityRepository = nationalityRepository;
        }
        [HttpPost]
        public IActionResult Post(NationalityDTO nationalityDTO)
        {
            _nationalityRepository.AddNationality(nationalityDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _nationalityRepository.DeleteNationality(id);
                return Ok();
            }
            catch(NullReferenceException)
            {
                return NotFound("Nationlity Not found");
            }
        }
    }
}
