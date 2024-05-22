using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesAPI2.Data.Dtos;
using FilmesAPI2.Models;
namespace FilmesAPI2.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        { 
            CreateMap<CreateSessaoDto, Sessao>(); // Adicionando o mapeamento de CreateSessaoDto para Sessao
            CreateMap<ReadSessaoDto, Sessao>();// Adicionando o mapeamento de Sessao para ReadSessaoDto
            CreateMap<Sessao, ReadSessaoDto>().ForMember(sessaoDto => sessaoDto.NomeCinema, opt=> opt.MapFrom(sessao => sessao.Cinema.NomeCinema)); 
        }
    }
}