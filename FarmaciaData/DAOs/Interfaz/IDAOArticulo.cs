using FarmaciaData.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaData.Datos.Interfaz
{
    public interface IDAOArticulo
    {
        List<Articulo> ObtenerArticulos();
        bool Crear(Articulo articulo);
        bool Actualizar(Articulo articulo);
        bool Borrar(int nro);
        //List<Articulo> ObtenerArticulosPorFiltros(DateTime desde, DateTime hasta, string cliente);
        //Articulo ObtenerArticuloPorNro(int nro);
        //DataTable ObtenerReporte(DateTime desde, DateTime hasta);

    }
}
