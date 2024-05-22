using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesAPI2.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilmesAPI2.Models;
using FilmesAPI2.Data;
namespace FilmesAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : Controller
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornaEnderecos), new { id = endereco.Id }, endereco);
        }
        [HttpGet]
        public IEnumerable <ReadEnderecoDto> RetornaEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take).ToList());
        }
        [HttpGet("{id}")]
        public IActionResult RetornaEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
                return NotFound("Endereço não encontrato no sistema");
            var EnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco); //Converte um endereco para um enderecoDto
            return Ok(EnderecoDto); //Retorna o Status code 200
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
                return NotFound("Endereço não encontrado");
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent(); //Retorna o status code 204 - No Content
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
                return NotFound("Endereço não encontrado");
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return NoContent();  //Retorna o status code 204 - No Content
        }
    }
}