using FarmaciaData.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaData.Fachada
{
    public interface IDataImp
    {
        List<Articulo> GetArticulos();
        //public List<Presupuesto> GetPresupuestos(DateTime desde, DateTime hasta, string cliente);

        //public Presupuesto GetPresupuestoById(int id);
        //public bool SavePresupuesto(Presupuesto presupuesto);

    }
}
