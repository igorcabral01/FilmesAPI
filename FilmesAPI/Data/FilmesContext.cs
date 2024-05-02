using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class FilmesContext : DbContext
{
    public FilmesContext(DbContextOptions<FilmesContext>opts)
        : base(opts)
    {
        
    }

    public DbSet<Filmes> filmes { get; set; }

    internal object Skip(int skip)
    {
        throw new NotImplementedException();
    }
}
