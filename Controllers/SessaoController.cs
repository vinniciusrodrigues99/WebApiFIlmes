using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesAPI2.Data;
using FilmesAPI2.Data.Dtos;
using FilmesAPI2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _contextSessao;
        private IMapper _mapper;
        public SessaoController(FilmeContext contextSessao, IMapper mapper)
        {
        _contextSessao = contextSessao;
        _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionandoSessao([FromBody] CreateSessaoDto sessaoDto)
        {
        Sessao sessao = _mapper.Map<Sessao>(sessaoDto); //Convertendo sessaoDto para sessao
        _contextSessao.Sessoes.Add(sessao);
        _contextSessao.SaveChanges();
        return CreatedAtAction(nameof(RetornaSessoesPorID), new {Id = sessao.Id}, sessao);
        }

        [HttpGet("{id}")] //Retorna sessao por ID
        public IActionResult RetornaSessoesPorID([FromQuery]int id)
        {
            Sessao sessao = _contextSessao.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if(sessao == null)
            return NotFound("Sessão não encontrada");
            CreateCinemaDto sessaoDto = _mapper.Map<CreateCinemaDto>(sessao); //Converte uma sessao para uma sessaoDto
            return Ok(sessaoDto); //Retorna o Status code 200 e o filme
        }
        [HttpGet]
        public IEnumerable<ReadSessaoDto> RetornaSessoes([FromQuery] int skip = 0, [FromQuery] int take = 40)
        {
            return _mapper.Map<List<ReadSessaoDto>>(_contextSessao.Sessoes.ToList());
        }
    }
}
