using Microsoft.EntityFrameworkCore;
using FilmesAPI2.Models;

namespace FilmesAPI2.Data
{
	public class FilmeContext : DbContext	//Classe que representa o contexto do banco de dados
	{
		public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
		{

		}
		public DbSet<Filme> Filmes { get; set; } //Usado para representar uma tabela ou coleção de entidades no banco de dados
		public DbSet<Cinema> Cinemas { get; set; } //Usado para representar uma tabela ou coleção de entidades no banco de dados
		public DbSet<Endereco> Enderecos { get; set; } //

		public DbSet<Sessao> Sessoes { get; set; } //Usado para representar a entidade Sessao no banco de dados
	}
}
