using Microsoft.AspNetCore.Mvc;
using FilmesAPI2.Models;
using FilmesAPI2.Data;
using FilmesAPI2.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
namespace FilmesAPI2.Controllers
{
	[ApiController]
	[Route("[controller]")] // Define que a rota do controller é o nome da classe, sem o sufixo Controller, neste caso Filme.
	public class FilmeController: ControllerBase
	{
		//private static List<Filme> filmes = new List<Filme>();
		//private static int id = 0;
		private FilmeContext _context; //: Este é um campo privado na classe FilmeController que armazenará uma instância do contexto do banco de dados FilmeContext.
		private IMapper _mapper;


		public FilmeController(FilmeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpPost] // a partir desse momento, o método é um POST
		public  IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDTO) //A notação [FromBody] indica que o parâmetro filme será passado no corpo da requisição
		{
			//filme.Id = ++id;
			//filmes.Add(filme);  // Adiciona um filme
			Filme filme = _mapper.Map<Filme>(filmeDTO);
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

		[HttpGet("{id}")] //EndPoint que retorna um filme por id
		public IActionResult RetornaFilmePorID(int id) // a notaçaõ {id} indica que o parâmetro id será passado na URL
		{
			var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
			if (filme == null)
				return NotFound(); //Neste caso será retornado o status code 404 - Not Found
			var filmeDTO = _mapper.Map<ReadFilmeDto>(filme);
			return Ok(filme); //Neste caso será retornado o status code 200 e o filme
		}
		[HttpPut("{id}")] 
		public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
		{
			var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
			if (filme == null)
			{
				return NotFound();
			}

			if (filmeDto.Titulo != null)
			{
				filme.Titulo = filmeDto.Titulo;
			}

			if (filmeDto.Diretor != null)
			{
				filme.Diretor = filmeDto.Diretor;
			}

			if (filmeDto.Duracao != null) // Certifique-se de que filmeDto.Duracao é um double?
			{
				filme.Duracao = filmeDto.Duracao;
			}

			if (filmeDto.Genero != null)
			{
				filme.Genero = filmeDto.Genero;
			}
			_context.SaveChanges();
			return NoContent();
			//_mapper.Map(filmeDto, filme); // Atualiza o filme com os dados do filmeDto
			 // Retorna o status code 204 - No Content
		}
		[HttpPatch("{id}")]
		public IActionResult AtualizarFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)  //Atualizando através da biblioteca NewtonSoftJson
		{
			var filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
			if (filme == null)
				return NotFound();
			var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
			patch.ApplyTo(filmeParaAtualizar, ModelState);
			if(!TryValidateModel(filmeParaAtualizar))
			{
				return ValidationProblem(ModelState);
			}
			_mapper.Map(filmeParaAtualizar, filme);
			_context.SaveChanges();
			return NoContent();
		}
		[HttpDelete("{id}")]
		public IActionResult DeletaFilmes(int id)
		{
			var filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
			if(filme == null)
			{
				return NotFound();
			}
			_context.Filmes.Remove(filme);
			_context.SaveChanges();
			return NoContent();
		}

	}
}
//Em resumo, este código está injetando o contexto do banco de dados FilmeContext na classe FilmeController por meio do construtor, permitindo que a classe FilmeController interaja com o banco de dados para buscar e manipular dados relacionados a filmes. Esse padrão de injeção de dependência é comum em aplicativos ASP.NET Core e ajuda a promover a modularidade e a testabilidade do código.