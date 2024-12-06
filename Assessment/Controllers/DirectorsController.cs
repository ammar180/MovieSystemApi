using Assessment.DTOs.Get;
using Assessment.DTOs.Post;
using Assessment.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorsController(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }
        [HttpPost]
        public IActionResult PostDirector(DirectorDTO directorDTO)
        {
            try
            {
                _directorRepository.AddDirector(directorDTO);
                return Created();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutDirector(int id, PostDirectorsAndMovieDTO dto)
        {
            try
            {
                _directorRepository.UpdateDirector(id, dto.Director, dto.DirectorMovies);
                return Ok();
            }catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            try
            {
                _directorRepository.RemoveDirector(id);
                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
