using Assessment.Data;
using Assessment.DTOs.Get;
using Assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AssessmentContext _context;

        public CategoryRepository(AssessmentContext context)
        {
            _context = context;
        }

        public void AddCategory(CategoryDTO categoryDTO)
        {
            _context.Categories.Add(new Category
            {
                Name = categoryDTO.Name
            });
            _context.SaveChanges();
        }

        public void UpdateCategory(int id, CategoryDTO categoryDTO)
        {
            var category = _context.Categories
               .FirstOrDefault(c => c.Id == id)
               ?? throw new NullReferenceException();

            category.Name = categoryDTO.Name;
            _context.SaveChanges();
        }
    }
}
