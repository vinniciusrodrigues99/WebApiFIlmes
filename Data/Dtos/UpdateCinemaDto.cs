using System.ComponentModel.DataAnnotations;

namespace FilmesAPI2.Data.Dtos
{
    public class UpdateCinemaDto
    {
      [Required(ErrorMessage = "O nome do cinema é um campo obrigatório")]
      public string NomeCinema { get; set; } 
    }
}