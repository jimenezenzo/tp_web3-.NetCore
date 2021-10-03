using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public class Receta
    {
        public int id { get; set; }
        public int tiempoCoccion { get; set; }
        public string descripcion { get; set; }
        public List<Ingrediente> ingredientes { get; set; }
        public TipoReceta tipoReceta { get; set; }
    }
}
