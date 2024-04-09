using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI2.Data.Dtos
{
    public class ReadEnderecoDto
    {
        public int Id {get; set;}
        [Required(ErrorMessage ="O nome da rua é obrigatório para cadastro do endereço")]
        [StringLength(300, ErrorMessage = "O nome da rua é muito grande")]
        public string Rua {get; set;}
        public int? Numero {get; set;}
        [Required(ErrorMessage = "O nome do bairro é obrigatório para cadastro do endereço")]
        public string Bairro {get; set;}
        [Required(ErrorMessage = "O nome da cidade é obrigatório para cadastro do endereço")]
        public string Cidade {get; set;}
        [Required(ErrorMessage = "O nome do estado é obrigatório para cadastro do endereço")]
        public string Estado {get; set;}
        [Required(ErrorMessage = "O CEP é obrigatório para cadastro do endereço")]
        [StringLength(8, ErrorMessage = "O CEP deve ter 8 caracteres")]
        public string Cep {get; set;}
        public DateTime HoraConsulta {get; set;} = DateTime.Now;

        public string Cinema { get; set; } //Propriedade de cinema
    }
}