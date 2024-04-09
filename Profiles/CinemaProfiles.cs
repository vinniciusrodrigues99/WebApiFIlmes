using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesAPI2.Data.Dtos;
using FilmesAPI2.Models;
namespace FilmesAPI2.Profiles
{
    public class CinemaProfiles: Profile
    {
        public CinemaProfiles()
        {
            CreateMap<CreateCinemaDto, Cinema>(); // Adicionando o mapeamento de CreateCinemaDto para Cinema
            CreateMap<Cinema, ReadCinemaDto>().ForMember(cinemaDto => cinemaDto.Endereco, opt => opt.MapFrom(cinema => cinema.Endereco));
			CreateMap<UpdateCinemaDto, Cinema>(); // Adicionando o mapeamento de Cinema para UpdateCinemaDto
            CreateMap<Cinema, UpdateCinemaDto>(); // É usado quando você quer enviar uma instância de Filme como resposta para o cliente
        }
    }
}