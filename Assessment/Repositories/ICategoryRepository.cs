using Assessment.DTOs.Get;

namespace Assessment.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(CategoryDTO categoryDTO);
        void UpdateCategory(int id, CategoryDTO categoryDTO);
    }
}