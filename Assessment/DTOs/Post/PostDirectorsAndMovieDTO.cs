using Assessment.DTOs.Get;
using System.ComponentModel.DataAnnotations;

namespace Assessment.DTOs.Post
{
    public class PostDirectorsAndMovieDTO
    {
        public DirectorDTO Director { get; set; }
        public List<PostDirectorMovieDTO>? DirectorMovies { get; set; }
    }
    public class PostDirectorMovieDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseYear { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
