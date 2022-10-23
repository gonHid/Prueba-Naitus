using Microsoft.EntityFrameworkCore;
using Prueba_Naitus.Models;


namespace Practice.DataAccess
{
    public class testNaitusDBContext : DbContext
    {
        public testNaitusDBContext(DbContextOptions<testNaitusDBContext> options):base(options)
        {

        }

        //add tables
     
        public DbSet<User>? Usuarios { get; set; }
        public DbSet<ImageFile>? Imagenes { get; set; }


    }
}
