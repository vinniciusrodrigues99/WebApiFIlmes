using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FilmesAPI2.Models
{
    public class Cinema
    {
        [Key] //Chave primária no banco de dados
        [Required]
        public int Id { get; set;}
        [Required(ErrorMessage = "O nome do cinema é obrigatório")]
        public string NomeCinema {get; set;}
        [Required(ErrorMessage = "O id do endereço é obrigatório")]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Sessao> Sessoes {get; set;}
    }
}