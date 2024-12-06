using System.ComponentModel.DataAnnotations;

namespace Assessment.DTOs.Get
{
    public class CategoryDTO
    {
        [Required]
        public string Name { get; set; }
    }
}