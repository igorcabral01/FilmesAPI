using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filmes
{
    //CRIANDO CHAVE PRIMARIA PARA O DB
    //APOS ABRIR TERMINAL NUGGET
    //- GERANDO A MIGRATION Add-Migration CriandoTabelaDeFilme
    // SUBINDO NO DB COM Update-Database
    [Key]
    [Required]
    public int Id { get;  set; }
    [Required(ErrorMessage ="O titílo é obrigatorio")]
    [MaxLength(100,ErrorMessage ="O Titulo tem que ser menor que 100 carecteres")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O Genero é obrigatorio")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A duração é obrigatorio")]
    public string Duracao { get; set; }
    [Required(ErrorMessage = "O Ano do filme é obrigatorio")]
    [Range(1930,2024,ErrorMessage ="Permito apenas filmes de 1930 ate 2024")]
    public int Ano { get; set; }

}
