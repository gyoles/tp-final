using System.Text.RegularExpressions;

namespace FarmaciaWebAPI.Entities
{
    public class Articulo
    {
        private int id;
        private string descripcion;
        private Marca marca;
        private Rubro rubro;
        private float precio;
        private int cantidad;
        private bool medicinal;
        private bool ventaLibre;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public bool Medicinal
        {
            get { return medicinal; }
            set { medicinal = value; }
        }
        public bool VentaLibre
        {
            get { return ventaLibre; }
            set { ventaLibre = value; }
        }
        public Marca Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public Rubro Rubro
        {
            get { return rubro; }
            set { rubro = value; }
        }

        public Articulo()
        {
            id = 0;
            descripcion = string.Empty;
            marca = new Marca(0, "");
            rubro = new Rubro(0, "");
            precio = 0;
            cantidad = 0;
            medicinal = false;
            ventaLibre = false;
        }
        public Articulo(int id, string descripcion, Marca marca, Rubro rubro, float precio, int cantidad, bool medicinal, bool ventaLibre)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.marca = marca;
            this.rubro = rubro;
            precio = 0;
            cantidad = 0;
            this.ventaLibre = ventaLibre;
            this.medicinal = medicinal;
        }
        public override string ToString()
        {
            return this.descripcion + " " + this.marca + " " + this.precio;
        }
    }
}
