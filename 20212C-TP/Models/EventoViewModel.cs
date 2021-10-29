using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace _20212C_TP.Models
{
    public class EventoViewModel
    {
        [Required(ErrorMessage = "Ingrese el Nombre")]
        [StringLength(maximumLength:50, ErrorMessage ="no se puede superar los 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la Fecha")]
        [Customfecha(ErrorMessage = "La fecha debe superar las 24 horas de hoy")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Ingrese la Cantidad Comensales")]
        [Range(1, int.MaxValue, ErrorMessage = "No se pueden crear eventos sin comensales")]
        public int CantidadComensales { get; set; }

        [Required(ErrorMessage = "Ingrese la Ubicacion")]
        [StringLength(maximumLength: 50, ErrorMessage = "no se puede superar los 50 caracteres")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "Ingrese una Precio")]
        [Range(0.01,double.MaxValue,ErrorMessage ="No se pueden crear eventos gratis")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Ingrese una Foto")]
        public IFormFile Foto { get; set; }
    }

    public class Customfecha : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime fecha = (DateTime)value;

            if(fecha <= DateTime.Now.AddDays(1))
            {
                return false;
            }
            return true;
        }
    }
}
