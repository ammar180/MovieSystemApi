using Assessment.DTOs.Get;

namespace Assessment.Repositories
{
    public interface INationalityRepository
    {
        void AddNationality(NationalityDTO nationalityDTO);
        void DeleteNationality(int id);
    }
}