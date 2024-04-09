namespace FilmesAPI2.Data.Dtos
{
	public class ReadFilmeDto //: Esta classe é um DTO (Data Transfer Object) que representa um filme que será retornado para o cliente.
	{
		public string Titulo { get; set; }

		public string Genero { get; set; }

		public int Duracao { get; set; }

		public DateTime HoraDaConsulta { get; set; } = DateTime.Now; // Adicionando a hora da consulta

	}
}
