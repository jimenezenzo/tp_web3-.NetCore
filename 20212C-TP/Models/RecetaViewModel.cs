using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Models
{
    public class RecetaViewModel
    {
        [Required]
        public int IdReceta { get; set; }

        [Required]
        public int IdCocinero { get; set; }

        [Required]
        public string Nombre{ get; set; }

        [Required]
        public int TiempoCoccion { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Ingredientes { get; set; }

        [Required]
        public int IdTipoReceta { get; set; }
    }
}
