using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public class Ingrediente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }

        public Ingrediente(int id, string nombre, int cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.cantidad = cantidad;
        }
    }
}
