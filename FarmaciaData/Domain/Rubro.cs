using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaData.Dominio
{
    internal class Rubro
    {
        public int idRubro { get; set; }
        public string descripcion { get; set; }

        public Rubro()
        {
            idRubro = 0;
            descripcion = null;
        }

        public Rubro(int id, string descripcion)
        {
            this.idRubro = id;
            this.descripcion = descripcion;
        }

        public override string ToString()
        {
            return this.idRubro + " - " + this.descripcion;
        }

    }
}
