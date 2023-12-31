﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmaciaData.Dominio;
using FarmaciaData.Datos.Interfaz;

namespace FarmaciaData.Datos.Implementacion
{
    public class DAOArticulo : IDAOArticulo
    {
        //public int ObtenerProximoNro()
        //{
        //    string sp = "SP_PROXIMO_ID";
        //    return HelperDB.ObtenerInstancia().ConsultaEscalarSQL(sp, "@next");
        //}

        public List<Articulo> ObtenerArticulos()
        {
            List<Articulo> lst = new List<Articulo>();

            string sp = "SP_CONSULTAR_ARTICULOS";
            DataTable t = HelperDB.ObtenerInstancia().ConsultaSQL(sp, null);

            foreach (DataRow dr in t.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                int id = int.Parse(dr["id_articulo"].ToString());
                string descripcion = dr["descripcion"].ToString();
                string marca = dr["marca_nombre"].ToString();
                string rubro = dr["rubro_nombre"].ToString();
                int precio = int.Parse(dr["precio"]).ToString();
                int cantidad = (int)(dr["cantidad"]).ToString();
                bool medicinal = dr["precio"].ToString();
                int precio = int.Parse(dr["precio"].ToString();

                //int nro = int.Parse(dr["id_producto"].ToString());
                //string nombre = dr["n_producto"].ToString();
                //double precio = double.Parse(dr["precio"].ToString());
                //bool activo = dr["activo"].ToString().Equals("S");

                Articulo aux = new Articulo(id, descripcion, marca, rubro, precio, cantidad, medicinal, ventaLibre);
                //aux.Activo = activo;
                lst.Add(aux);
            }

            return lst;
        }

        public bool Crear(Articulo articulo)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {

                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_INSERTAR_MAESTRO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", articulo.Cliente);
                cmd.Parameters.AddWithValue("@dto", articulo.Descuento);
                cmd.Parameters.AddWithValue("@total", articulo.CalcularTotalConDescuento());

                //parámetro de salida:
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@presupuesto_nro";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);
                cmd.ExecuteNonQuery();

                int presupuestoNro = (int)pOut.Value;

                SqlCommand cmdDetalle;
                int detalleNro = 1;
                foreach (DetallePresupuesto item in articulo.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", presupuestoNro);
                    cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", item.Producto.ProductoNro);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.ExecuteNonQuery();

                    detalleNro++;
                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public bool Actualizar(Articulo articulo)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_MODIFICAR_MAESTRO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", articulo.Cliente);
                cmd.Parameters.AddWithValue("@dto", articulo.Descuento);
                cmd.Parameters.AddWithValue("@total", articulo.CalcularTotalConDescuento());
                cmd.Parameters.AddWithValue("@presupuesto_nro", articulo.PresupuestoNro);
                cmd.ExecuteNonQuery();

                SqlCommand cmdDetalle;
                int detalleNro = 1;
                foreach (DetallePresupuesto item in articulo.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", articulo.PresupuestoNro);
                    cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", item.Producto.ProductoNro);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.ExecuteNonQuery();

                    detalleNro++;
                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public bool Borrar(int nro)
        {
            string sp = "SP_ELIMINAR_PRESUPUESTO";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@presupuesto_nro", nro));
            int afectadas = HelperDB.ObtenerInstancia().EjecutarSQL(sp, lst);
            return afectadas > 0;
        }

        //public List<Presupuesto> ObtenerPresupuestosPorFiltros(DateTime desde, DateTime hasta, string cliente)
        //{
        //    List<Presupuesto> presupuestos = new List<Presupuesto>();
        //    string sp = "SP_CONSULTAR_PRESUPUESTOS";
        //    List<Parametro> lst = new List<Parametro>();
        //    lst.Add(new Parametro("@fecha_desde", desde));
        //    lst.Add(new Parametro("@fecha_hasta", hasta));
        //    lst.Add(new Parametro("@cliente", cliente));
        //    DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        Presupuesto presupuesto = new Presupuesto();
        //        presupuesto.Cliente = row["cliente"].ToString();
        //        presupuesto.PresupuestoNro = int.Parse(row["presupuesto_nro"].ToString());
        //        presupuesto.Fecha = DateTime.Parse(row["fecha"].ToString());
        //        presupuesto.Descuento = double.Parse(row["descuento"].ToString());
        //        presupuestos.Add(presupuesto);
        //    }

        //    return presupuestos;
        //}

        //public DataTable ObtenerReporte(DateTime desde, DateTime hasta)
        //{
        //    string sp = "SP_REPORTE_PRODUCTOS";
        //    List<Parametro> lst = new List<Parametro>();
        //    lst.Add(new Parametro("@fecha_desde", desde));
        //    lst.Add(new Parametro("@fecha_hasta", hasta));
        //    DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
        //    return dt;
        //}

        //public Presupuesto ObtenerPresupuestoPorNro(int nro)
        //{
        //    Presupuesto presupuesto = new Presupuesto();
        //    string sp = "SP_CONSULTAR_DETALLES_PRESUPUESTO";
        //    List<Parametro> lst = new List<Parametro>();
        //    lst.Add(new Parametro("@presupuesto_nro", nro));

        //    DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
        //    bool primero = true;

        //    foreach (DataRow fila in dt.Rows)
        //    {
        //        if (primero)
        //        {
        //            presupuesto.Cliente = fila["cliente"].ToString();
        //            presupuesto.Fecha = DateTime.Parse(fila["fecha"].ToString());
        //            presupuesto.Descuento = Double.Parse(fila["descuento"].ToString());
        //            primero = false;
        //        }
        //        int nroProducto = int.Parse(fila["id_producto"].ToString());
        //        string nombre = fila["n_producto"].ToString();
        //        double precio = double.Parse(fila["precio"].ToString());
        //        Producto producto = new Producto(nroProducto, nombre, precio);
        //        int cantidad = int.Parse(fila["cantidad"].ToString());
        //        DetallePresupuesto detalle = new DetallePresupuesto(producto, cantidad);
        //        presupuesto.AgregarDetalle(detalle);

        //    }

        //    return presupuesto;
        //}

    }
}
