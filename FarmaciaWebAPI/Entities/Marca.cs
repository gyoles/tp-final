namespace FarmaciaWebAPI.Entities
{
    public class Marca
    {
        public int idMarca { get; set; }
        public string descripcion { get; set; }

        public Marca()
        {
            idMarca = 0;
            descripcion = string.Empty;
        }
        public Marca(int id, string descripcion)
        {
            this.idMarca = id;
            this.descripcion = descripcion;
        }
        public override string ToString()
        {
            return idMarca + " - " + descripcion;
        }
    }

}
}
