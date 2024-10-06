using Microsoft.EntityFrameworkCore;
using SchoolProject.Entities;

namespace SchoolProject.DAL
{
    public class SchoolDBContext : DbContext
    {

        public SchoolDBContext(DbContextOptions<SchoolDBContext>options):base(options) { }

        public DbSet<Xeberler> Xeberler { get; set; }
        public DbSet<Telebeler> Telebeler { get; set; }

    }
}
