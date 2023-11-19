namespace FarmaciaWebAPI.Entities
{
    public class Rubro
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
}
