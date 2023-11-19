using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaData.Datos
{
    internal class HelperDB
    {
        private SqlConnection cnn;
        private SqlCommand cmd;

        public HelperDB()
        {
            cnn = new SqlConnection(@"Data Source=DESKTOP-0VC0DG0\\SQLEXPRESS;Initial Catalog=Droguería;Integrated Security=True");
        }

        //public bool AgregarArt(Articulo a)
        //{
        //    bool resultado = true;
        //    try
        //    {
        //        cnn.Open();
        //        cmd = new SqlCommand();
        //        cmd.Connection = cnn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "SP_ALTA_ART";
        //        cmd.Parameters.AddWithValue("@id_articulo", a.Id);
        //        cmd.Parameters.AddWithValue("@descripcion", a.Descripcion);
        //        cmd.Parameters.AddWithValue("@id_marca", a.Marca);
        //        cmd.Parameters.AddWithValue("@id_rubro", a.Rubro);
        //        cmd.Parameters.AddWithValue("@pre_unitario", a.Precio);
        //        cmd.Parameters.AddWithValue("@cantidad", a.Cantidad);
        //        cmd.Parameters.AddWithValue("@es_medicinal", a.Medicinal);
        //        cmd.Parameters.AddWithValue("@venta_libre", a.VentaLibre);

        //        resultado = cmd.ExecuteNonQuery() == 1;
        //        cnn.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        resultado = false;
        //    }
        //    return resultado;

        //}
        //public bool BorrarArt(Articulo a)
        //{
        //    bool resultado = true;
        //    try
        //    {
        //        cnn.Open();
        //        cmd = new SqlCommand();
        //        cmd.Connection = cnn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "SP_BAJA_ART";
        //        cmd.Parameters.AddWithValue("@id_articulo", a.Id);

        //        resultado = cmd.ExecuteNonQuery() == 1;
        //        cnn.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        resultado = false;
        //    }
        //    return resultado;
        //}

        //public bool ActualizarArt(Articulo a)
        //{
        //    bool resultado = true;
        //    try
        //    {
        //        cnn.Open();
        //        cmd = new SqlCommand();
        //        cmd.Connection = cnn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "SP_MODIFICAR_ART";
        //        cmd.Parameters.AddWithValue("@id_articulo", a.Id);
        //        cmd.Parameters.AddWithValue("@descripcion", a.Descripcion);
        //        cmd.Parameters.AddWithValue("@id_marca", a.Marca);
        //        cmd.Parameters.AddWithValue("@id_rubro", a.Rubro);
        //        cmd.Parameters.AddWithValue("@pre_unitario", a.Precio);
        //        cmd.Parameters.AddWithValue("@cantidad", a.Cantidad);
        //        cmd.Parameters.AddWithValue("@es_medicinal", a.Medicinal);
        //        cmd.Parameters.AddWithValue("@venta_libre", a.VentaLibre);

        //        resultado = cmd.ExecuteNonQuery() == 1;
        //        cnn.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        resultado = false;
        //    }
        //    return resultado;
        //}

        //public DataTable ConsultarArt(string nombreSP)
        //{
        //    cnn.Open();
        //    cmd = new SqlCommand();
        //    cmd.Connection = cnn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = nombreSP;
        //    DataTable dt = new DataTable();
        //    dt.Load(cmd.ExecuteReader());
        //    cnn.Close();
        //    return dt;
        //}

    }
}
