using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI2.Data.Dtos
{
    public class ReadSessaoDto
    {
        public int FilmeId {get; set;}

        public int? CinemaId {get; set;}

        public string NomeCinema {get; set;}
    }
}