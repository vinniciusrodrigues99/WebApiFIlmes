using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesAPI2.Data.Dtos;
using FilmesAPI2.Models;

namespace FilmesAPI2.Profiles
{
    public class EnderecoProfiles: Profile
    {
        public EnderecoProfiles()
        {
            CreateMap<CreateEnderecoDto, Endereco>(); // Adicionando o mapeamento de CreateEnderecoDto para Endereco
            CreateMap<Endereco, ReadEnderecoDto>().ForMember(enderecoDto => enderecoDto.NomeCinema, opt=> opt.MapFrom(endereco => endereco.Cinema.NomeCinema));
            CreateMap<UpdateEnderecoDto, Endereco>();
            CreateMap<Endereco, UpdateEnderecoDto>(); 
        }
    }
}