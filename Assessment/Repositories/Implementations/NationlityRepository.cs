using Assessment.Data;
using Assessment.DTOs.Get;
using Assessment.Models;

namespace Assessment.Repositories.Implementations
{
    public class NationlityRepository(AssessmentContext context) : INationalityRepository
    {
        private readonly AssessmentContext _context = context;

        public void AddNationality(NationalityDTO nationalityDTO)
        {
            _context.Nationalities.Add(new Nationality
            {
                Name = nationalityDTO.Name,
            }) ;
            _context.SaveChanges();
        }
        public void DeleteNationality(int id)
        {
            var natio = _context.Nationalities
                        .FirstOrDefault(n => n.Id == id) ?? throw new NullReferenceException();
            _context.Nationalities.Remove(natio);
            _context.SaveChanges();
        }
    }
}
