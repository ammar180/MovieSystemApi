using Assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Data
{
    public class AssessmentContext : DbContext
    {
        public AssessmentContext(DbContextOptions<AssessmentContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = default!;
        public DbSet<Director> Directors { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Nationality> Nationalities { get; set; } = default!;

    }
}
