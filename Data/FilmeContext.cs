using Microsoft.EntityFrameworkCore;
using FilmesAPI2.Models;

namespace FilmesAPI2.Data
{
	public class FilmeContext : DbContext	//Classe que representa o contexto do banco de dados
	{
		public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Sessao>()
				.HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId }); //Define a chave primária da entidade Sessao
			builder.Entity<Sessao>()
				.HasOne(sessao => sessao.Cinema) //Define o relacionamento entre a entidade Sessao e a entidade Cinema (um para um)
				.WithMany(cinema=> cinema.Sessoes) //Define o relacionamento entre a entidade Sessao e a entidade Cinema (um para muitos)
				.HasForeignKey(sessao => sessao.CinemaId); //Define a chave estrangeira da entidade Sessao
			builder.Entity<Sessao>()
				.HasOne(sessao => sessao.Filme) //Define o relacionamento entre a entidade Sessao e a entidade Filme (um para um)
				.WithMany(filme => filme.Sessoes) //Define o relacionamento entre a entidade Sessao e a entidade Filme (um para muitos)
				.HasForeignKey(sessao=> sessao.FilmeId); //Define a chave estrangeira da entidade Sessao
		}
		public DbSet<Filme> Filmes { get; set; } //Usado para representar uma tabela ou coleção de entidades no banco de dados
		public DbSet<Cinema> Cinemas { get; set; } //Usado para representar uma tabela ou coleção de entidades no banco de dados
		public DbSet<Endereco> Enderecos { get; set; } //
		public DbSet<Sessao> Sessoes { get; set; } //Usado para representar a entidade Sessao no banco de dados
	}
}
