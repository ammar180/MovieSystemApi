using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assessment.Data;
using Assessment.Models;
using Assessment.Repositories;
using Assessment.DTOs.Get;

namespace Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository MovieRepository)
        {
            _movieRepository = MovieRepository;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            try
            {
                IEnumerable<MovieDTO> result = _movieRepository.GetAllMoviesEager();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            try
            {
                MovieDTO result = _movieRepository.GetMovieById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult PostMovie(MovieDTO movieDTO)
        {
            try
            {
                _movieRepository.AddMovie(movieDTO);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
    }
}
