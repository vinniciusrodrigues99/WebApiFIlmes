
namespace FilmesAPI2.Data.Dtos
{
    public class ReadCinemaDto
    {
        public string Id { get; set; }

        public string NomeCinema { get; set; } 

        public DateTime HoraConsulta { get; set; } = DateTime.Now;

        public ReadEnderecoDto Endereco { get; set; } //Propriedade de endere�o 

        public ICollection <ReadSessaoDto> Sessoes { get; set; } //Propriedade de sess�es
    }
}