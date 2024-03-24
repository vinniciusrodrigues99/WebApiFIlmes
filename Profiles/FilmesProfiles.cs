using FilmesAPI2.Data.Dtos;
using FilmesAPI2.Models;
using AutoMapper;

namespace FilmesAPI2.Profiles
{
	public class FilmesProfiles : Profile
	{
		public FilmesProfiles() 
		{
			CreateMap<CreateFilmeDto, Filme>();
		}
	}
}
