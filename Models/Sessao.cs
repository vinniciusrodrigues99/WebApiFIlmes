using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FilmesAPI2.Models
{
    public class Sessao
    {
        // Define que a propriedade abaixo é a chave primária
        //public int Id {get; set;}
        public int? FilmeId {get; set;} // Chave estrangeira que servirá de identificador para o filme
        public virtual Filme Filme {get; set;} // Relacionamento com a tabela Filme
        public int? CinemaId {get; set;} //Chave estrangeira que servirá de identificador para o cinema
        public virtual Cinema Cinema {get; set;} //Relacionamento com a tabela cinema
        public DateTime HorarioDeInicio {get; set;}
        public DateTime HorarioDeTermino {get; set;}
    }
}