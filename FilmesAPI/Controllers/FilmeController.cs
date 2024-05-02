using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesAPI.Data;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmesContext _context;
    public FilmeController(FilmesContext context)
    {
        _context = context;
    }


    // FUNÇAO CRIADA PARA ADICIONAR FILME COM METODO POST, A PARTIR DO FROMBODY E DA LISTA PRIVADA DE FILMES E DO ID CRIADO
    [HttpPost]
    public IActionResult Adicionarfilme([FromBody] Filmes filme)
    {
          _context.Add(filme);
          _context.SaveChanges();
          return CreatedAtAction(nameof(BuscarFilme), new {id = filme.Id },filme);
    }
//FUNÇAO CRIADA PARA RETONAR O PARAMETRO DE EXIBIÇAO DE FILMES SE TIVER 100 ELE TEM COMO PADRAO MOSTRAR O FILME 0 ATE 0 10 OU
// O QUE O USUARIO QUISER A PARTIR DO FROMQUERY ?12&&
    [HttpGet]
    public IEnumerable<Filmes> ListarFilmesAdicionados([FromQuery]int skip= 0,[FromQuery] int take = 10)
    {
        return _context.filmes.Skip(skip).Take(take);
    }
    //FUNÇAO IACTION PARA RETORNAR O STATUS CODE COM BASE NA BUSCA DO ID DO FILME QUE FOI ADIOCIONADO NA LISTA DE FILMES
    [HttpGet("{id}")]
    public IActionResult BuscarFilme(int id)
    {
        var filme = _context.filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}


