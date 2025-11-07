using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Entities
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Você deve preencher a data e horário da reserva")]
        public DateTime DataHoraReserva { get; set; }


        public required string UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; } = null!;

        public required int LugarId { get; set; }

        [ForeignKey(nameof(LugarId))]
        public Lugar Lugar { get; set; } = null!;
    }
}