using Microsoft.AspNetCore.Mvc;
using FilmesAPI2.Models;
using FilmesAPI2.Data;
namespace FilmesAPI2.Controllers
{
	[ApiController]
	[Route("[controller]")] // Define que a rota do controller é o nome da classe, sem o sufixo Controller, neste caso Filme.
	public class FilmeController: ControllerBase
	{
		//private static List<Filme> filmes = new List<Filme>();
		//private static int id = 0;
		private FilmeContext _context;

		public FilmeController(FilmeContext context)
		{
			_context = context;
		}

		[HttpPost] // a partir desse momento, o método é um POST
		public  IActionResult AdicionaFilme([FromBody] Filme filme) //A notação [FromBody] indica que o parâmetro filme será passado no corpo da requisição
		{
			//filme.Id = ++id;
			//filmes.Add(filme);  // Adiciona um filme
			_context.Filmes.Add(filme);
			_context.SaveChanges();
			Console.WriteLine(filme.Titulo);
			Console.WriteLine(filme.Duracao);
			return CreatedAtAction(nameof(RetornaFilmePorID), new { id = filme.Id }, filme);
		}
		[HttpGet] // a partir desse momento, o método é um GET.
		public IEnumerable<Filme> RetornaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
		{
			return _context.Filmes.Skip(skip).Take(take);
		}

		[HttpGet ("{id}")] //EndPoint que retorna um filme por id
		public IActionResult RetornaFilmePorID(int id) // a notaçaõ {id} indica que o parâmetro id será passado na URL
		{
			var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
			if(filme == null)
			return NotFound(); //Neste caso será retornado o status code 404 - Not Found
			else
			return Ok(filme); //Neste caso será retornado o status code 200 e o filme
		}

	}
}
