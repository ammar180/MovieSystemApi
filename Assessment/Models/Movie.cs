using System.ComponentModel.DataAnnotations;

namespace Assessment.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Director> Directors { get; set; }
    }
}
