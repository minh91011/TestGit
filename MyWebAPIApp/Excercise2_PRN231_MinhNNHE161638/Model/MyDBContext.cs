using Microsoft.EntityFrameworkCore;

namespace Excercise2_PRN231_MinhNNHE161638.Model
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options):base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(e =>
            {
                e.HasIndex(x => x.StudentId).IsUnique();
                e.Property(e => e.StudentName).IsRequired().HasMaxLength(100);
            });
        }
    }
}
