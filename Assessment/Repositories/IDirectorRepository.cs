using Assessment.DTOs.Get;
using Assessment.DTOs.Post;

namespace Assessment.Repositories
{
    public interface IDirectorRepository
    {
        void AddDirector(DirectorDTO directorDTO);
        void RemoveDirector(int id);
        void UpdateDirector(int id, DirectorDTO directorDTO, List<PostDirectorMovieDTO>? movieDTO);
    }
}