using System.ComponentModel.DataAnnotations;

namespace FilmesAPI2.Models
{
	//Os métodos devem ter os mesmos nomes dos atributos de parâmetros que serão passados no corpo da requisição.
	public class Filme //Essa classe é um modelo de dados que representa um filme
	{
		[Key]
		[Required]
		public int Id { get; set;}
		[Required(ErrorMessage = "O título do filme é obrigatório")] // Define que o campo é obrigatório
		[StringLength(300)] //limita o tamanho de caracteres de uma string
		public string? Titulo { get; set;} 
		[Required] 
		public string? Diretor { get; set;}
		[Required]
		[MaxLength(30, ErrorMessage = "O tamanho do gênero não pode exceder 30 caracteres")] // Define que o campo deve ter no máximo 30 caracteres
		public string? Genero { get; set; }
		// Define que o campo deve estar entre 70 e 600
		[Required]
		[Range(70, 600, ErrorMessage ="A duração deve estar entre 70 e 600 minutos")] 
		public double Duracao { get; set; } 
		public virtual ICollection<Sessao> Sessoes {get; set;} //Relacionamento com a tabela Sessao indicando que um filme pode ter várias sessões
	}
}
