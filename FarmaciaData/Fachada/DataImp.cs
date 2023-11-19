using FarmaciaData.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaData.Fachada
{
    public class DataApiImp : IDataApi
    {
        private IDaoPresupuesto dao;

        public DataApiImp()
        {
            //dao = new PresupuestoDao();
        }

        public List<Articulo> GetProductos()
        {
            return dao.ObtenerProductos();
        }

        //public bool SavePresupuesto(Presupuesto presupuesto)
        //{
        //    return dao.Crear(presupuesto);
        //}

        //public Presupuesto GetPresupuestoById(int id)
        //{
        //    return dao.ObtenerPresupuestoPorNro(id);
        //}

        //public List<Presupuesto> GetPresupuestos(DateTime desde, DateTime hasta, string cliente)
        //{
        //    return dao.ObtenerPresupuestosPorFiltros(desde, hasta, cliente);
        //}
    }
}
