using Assessment.Models;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Assessment.DTOs.Get
{
    public class MovieDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseYear { get; set; }
        public CategoryDTO Category { get; set; }
        public List<DirectorDTO> Directors { get; set; }
    }
}
