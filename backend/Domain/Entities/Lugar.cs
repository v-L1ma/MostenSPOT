using System.ComponentModel.DataAnnotations;
using backend.Domain.Enums;

namespace backend.Domain.Entities
{
    public class Lugar
    {
        [Key]
        public int Id { get; set; }
        public required string Posicao { get; set; }
        public StatusCadeira Status { get; set; } = StatusCadeira.Disponivel;
    }
}