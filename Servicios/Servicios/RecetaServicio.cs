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
            Ingrediente cebolla = new Ingrediente(3, "cebolla", 3);
            List<Ingrediente> ingredientes = new List<Ingrediente> { papa, zanahoria };
            List<Ingrediente> ingredientes2 = new List<Ingrediente> { papa, zanahoria, cebolla };

            Receta receta = new Receta();
            receta.id = 1;
            receta.tiempoCoccion = 3;
            receta.tipoReceta = TipoReceta.Casera;
            receta.descripcion = "It is a long established fact that a reader will be distracted by the readable" +
                " content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution";
            receta.ingredientes = ingredientes;
            this.agregarReceta(receta);

            Receta receta2 = new Receta();
            receta2.id = 2;
            receta2.tiempoCoccion = 1;
            receta2.tipoReceta = TipoReceta.Casera;
            receta2.descripcion = "It is a long established fact that a reader will be distracted by the readable" +
                " content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution";
            receta2.ingredientes = ingredientes;
            this.agregarReceta(receta2);

            Receta receta3 = new Receta();
            receta3.id = 3;
            receta3.tiempoCoccion = 4;
            receta3.tipoReceta = TipoReceta.Gourmet;
            receta3.descripcion = "It is a long established fact that a reader will be distracted by the readable" +
                " content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution";
            receta3.ingredientes = ingredientes2;
            this.agregarReceta(receta3);
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
