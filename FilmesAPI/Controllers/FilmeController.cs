using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filmes> filmes = new List<Filmes>();
    private static int Id = 1;

    [HttpPost]
    public void adicionarfilme([FromBody] Filmes filme)
    {
        filme.Id = Id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Genero);
    }

    [HttpGet]
    public IEnumerable<Filmes> ListarFilmesAdicionados([FromQuery]int skip= 0,[FromQuery] int take = 10)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public Filmes? BuscarFilme(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }
}


