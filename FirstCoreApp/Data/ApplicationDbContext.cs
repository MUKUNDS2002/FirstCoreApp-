using FirstCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<StudentsModel> Students { get; set; }
        public DbSet<ManagementModel> Management { get; set; }
        public DbSet<TeacherModal> Teacher { get; set; }
        public DbSet<FirstCoreApp.Models.StudentData> StudentData { get; set; }

    }
}
