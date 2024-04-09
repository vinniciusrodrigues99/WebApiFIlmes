using System.ComponentModel.DataAnnotations;

namespace FilmesAPI2.Data.Dtos {
 
 public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O nome do cinema é obrigatório")]
        public string NomeCinema { get; set; }
        [Required(ErrorMessage = "O endereço é obrigatório")]
        public int EnderecoId { get; set; } // Adicionando o atributo EnderecoId para fazer o relacionamento com a tabela Endereco
    }
 }