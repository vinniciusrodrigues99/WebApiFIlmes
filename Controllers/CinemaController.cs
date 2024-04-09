using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesAPI2.Data;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI2.Data.Dtos;
using FilmesAPI2.Models;

namespace FilmesAPI2.Controllers
{
    [ApiController] //Define que a classe é uma controller
    [Route("[Controller]")] //Define que a rota do controller é o nome da classe, sem o sufixo Controller, neste caso Cinema.
    public class CinemaController: ControllerBase
    {
        private FilmeContext _context; //Este é um campo privado na classe CinemaController que armazenará uma instância do contexto do banco de dados FilmeContext.
        private IMapper _mapper; //Este é um campo privado na classe CinemaController que armazenará uma instância do mapeador de objetos AutoMapper.

        public CinemaController(FilmeContext context, IMapper mapper) // Criando um construtor para a classe CinemaController
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema); //Adicionando uma instância da entidade Cinema, ou seja criando uma nova linha na tabela Cinemas
            _context.SaveChanges(); //Fazendo a persistência dos dados no banco de dados
            return CreatedAtAction(nameof (RetornaCinemas), new {ìd = cinema.Id}, cinema); //Retorna o status code 201 - Created, e o cinema criado com um cabeçalho contendo a localização do recurso criado
        }

        [HttpGet]
        public IEnumerable <ReadCinemaDto> RetornaCinemas([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList()); //Retorna uma lista de cinemas
        }
        [HttpGet("{id}")] //parâmetros de rotas
        public IActionResult RetornaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id); //Busca um cinema pelo id
            if(cinema == null)
                return NotFound();
            var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema); //Converte um cinema para um cinemaDto
            return Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema == null)
            return NotFound("Cinema não encontrado");
            _mapper.Map(cinemaDto, cinema); //Atualiza um cinema com base em um cinemaDto
            _context.SaveChanges(); //Fazendo a persistência dos dados no banco de dados
            return NoContent(); //Retorna o status code 204 - No Content
        }

        [HttpDelete("{nomeCinema}")] //EndPoint que deleta um cinema através do parâmetro nomeCinema
        public IActionResult DeletaCinema(string nomeCinema)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.NomeCinema == nomeCinema);
            if(cinema == null)
            return NotFound("Cinema não encontrado");
            _context.Cinemas.Remove(cinema); //Remove um cinema
            _context.SaveChanges(); //Fazendo a persistência dos dados no banco de dados
            return NoContent(); //Retorna o status code 204 - No Content
        }

        [HttpDelete("{id}/por-id")] //EndPoint que deleta um cinema através do parâmetro nomeCinema
        public IActionResult DeletaCinemaPorID(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema == null)
            return NotFound("Cinema não encontrado");
            _context.Cinemas.Remove(cinema); //Remove um cinema
            _context.SaveChanges(); //Fazendo a persistência dos dados no banco de dados
            return NoContent(); //Retorna o status code 204 - No Content
        }

    }
}