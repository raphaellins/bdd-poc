using Microsoft.EntityFrameworkCore;
using pisoms.Models;

namespace pisoms.Data
{

    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        //TODOD dotnet add package Microsoft.EntityFrameworkCore.InMemory

        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
    }
}