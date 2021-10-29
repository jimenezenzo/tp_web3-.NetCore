using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Models
{
    public class ReservaViewModel
    {
        [Required]
        public int IdReceta { get; set; }
        [Required]
        public int CantidadComensales { get; set; }
    }
}
