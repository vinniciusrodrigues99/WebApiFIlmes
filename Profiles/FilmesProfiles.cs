using FilmesAPI2.Data.Dtos;
using FilmesAPI2.Models;
using AutoMapper;

namespace FilmesAPI2.Profiles
{
	public class FilmesProfiles : Profile //Classe que representa o perfil de mapeamento de filmes
	{
		public FilmesProfiles() 
		{
			CreateMap<CreateFilmeDto, Filme>();
			CreateMap<UpdateFilmeDto, Filme>(); // É usado quando você tem uma instância de UpdateFilmeDto (provavelmente vindo de uma solicitação do cliente) e você quer mapeá-la para uma instância de Filme para, por exemplo, atualizar um filme no banco de dados.
			CreateMap<Filme, UpdateFilmeDto>(); // É usado quando você quer enviar uma instância de Filme como resposta para o cliente
			CreateMap<Filme, ReadFilmeDto>();
		}
	}
}
