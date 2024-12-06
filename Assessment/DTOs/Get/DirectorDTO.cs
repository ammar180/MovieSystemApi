using Assessment.Models;
using System.ComponentModel.DataAnnotations;

namespace Assessment.DTOs.Get
{
    public class DirectorDTO
    {
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public NationalityDTO Nationality { get; set; }
    }
}