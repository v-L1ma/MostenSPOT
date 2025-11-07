using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Dtos.Reserva
{
    public class CriarReservaDTO
    {
        [Required(ErrorMessage = "Você deve preencher o campo {0}")]
        public DateTime DataHoraReserva { get; set; }
        [Required(ErrorMessage = "Você deve preencher o campo {0}")]
        public int LugarId { get; set; }
    }
}