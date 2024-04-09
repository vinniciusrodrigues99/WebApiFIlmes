using System.ComponentModel.DataAnnotations;

namespace FilmesAPI2.Data.Dtos
{
	public class CreateFilmeDto //: Esta classe é um DTO (Data Transfer Object) que representa um filme que será recebido do cliente.
	{
		[Required(ErrorMessage = "O título do filme é obrigatório")] // Define que o campo é obrigatório
		[StringLength(300)] //limita o tamanho de caracteres de uma string
		public string? Titulo { get; set; }
		[Required]
		public string? Diretor { get; set; }
		[Required]
		[StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")] // Define que o campo deve ter no máximo 30 caracteres
		public string? Genero { get; set; }
		// Define que o campo deve estar entre 70 e 600
		[Required]
		[Range(70, 600, ErrorMessage = "A duração deve estar entre 70 e 600 minutos")]
		public double Duracao { get; set; }
	}
}
