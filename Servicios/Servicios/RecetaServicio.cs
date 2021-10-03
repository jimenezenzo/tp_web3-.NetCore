using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Servicios
{
    public class RecetaServicio
    {
        private List<Receta> _recetas;

        public RecetaServicio()
        {
            this._recetas = new List<Receta>();

            Ingrediente papa = new Ingrediente(1, "papa", 2);
            Ingrediente zanahoria = new Ingrediente(2, "zanahoria", 1);
            List<Ingrediente> ingredientes = new List<Ingrediente> { papa, zanahoria };

            Receta receta = new Receta();
            receta.id = 1;
            receta.tiempoCoccion = 3;
            receta.tipoReceta = TipoReceta.Casera;
            receta.descripcion = "bla bla bla";
            receta.ingredientes = ingredientes;
            this.agregarReceta(receta);

            Receta receta2 = new Receta();
            receta2.id = 2;
            receta2.tiempoCoccion = 1;
            receta2.tipoReceta = TipoReceta.Casera;
            receta2.descripcion = "bla bla bla asdfsdfdsfsdfsdf";
            receta2.ingredientes = ingredientes;
            this.agregarReceta(receta2);
        }

        public List<Receta> obtenerRecetas()
        {
            return this._recetas;
        }

        public void agregarReceta(Receta receta)
        {
            this._recetas.Add(receta);
        }

        public Receta obtenerRecetaPorId(int id)
        {
            return this._recetas.Find(j => j.id == id);
        }
    }
}
