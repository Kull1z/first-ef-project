using Microsoft.EntityFrameworkCore;
using MovieApp.Domain;


namespace MovieApp.Data
{
    public class MoviesContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = MovieDb; Trusted_Connection = True;");
        }
    }
}
