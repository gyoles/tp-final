using FarmaciaData.Dominio;
using FarmaciaFrontEnd.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaciaFrontEnd
{
    public partial class FrmConsultarArt : Form
    {
        public FrmConsultarArt()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string url = string.Format("http://localhost:5031/articulos");
            //Si se consulta por cliente, la URL incluye un parámetro adicional cliente= 
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Articulo>>(result);
            dgvArticulos.Rows.Clear();
            if (lst != null)
            {
                foreach (Articulo articulo in lst)
                {
                    dgvArticulos.Rows.Add(new object[] {
                        articulo.Id,
                        articulo.Descripcion,
                        articulo.Marca,
                        articulo.Rubro,
                        articulo.Precio,
                        articulo.Cantidad,
                        articulo.Medicinal,
                        articulo.VentaLibre
                    });
                }
            }
            else
            {
                MessageBox.Show("Sin datos de articulos para los filtros ingresados", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
