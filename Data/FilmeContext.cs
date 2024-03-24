using Microsoft.EntityFrameworkCore;
using FilmesAPI2.Models;

namespace FilmesAPI2.Data
{
	public class FilmeContext : DbContext	
	{
		public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
		{

		}
		public DbSet<Filme> Filmes { get; set; } //Usado para representar uma tabela ou coleção de entidades no banco de dados
	}
}
