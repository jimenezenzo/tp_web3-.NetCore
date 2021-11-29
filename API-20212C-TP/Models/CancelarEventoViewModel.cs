using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_20212C_TP.Models
{
    public class CancelarEventoViewModel
    {
        [Required]
        public int IdCocinero { get; set; }
        [Required]
        public int IdEvento { get; set; }
    }
}
