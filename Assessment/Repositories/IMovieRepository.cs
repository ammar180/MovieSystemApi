using Assessment.DTOs.Get;
using Assessment.Models;

namespace Assessment.Repositories
{
    public interface IMovieRepository
    {
        void AddMovie(MovieDTO movieDTO);
        IEnumerable<MovieDTO> GetAllMoviesEager();
        MovieDTO GetMovieById(int id);
    }
}
