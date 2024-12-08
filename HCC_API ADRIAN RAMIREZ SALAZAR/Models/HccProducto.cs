namespace HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models
{
    public class HccProducto
    {
        public int pro_id { get; set; }
        public int alm_id { get; set; }
        public string pro_nombre { get; set; }
        public string pro_descripcion { get; set; }
        public decimal pro_precio { get; set; }
        public byte pro_estatus { get; set; }

        public virtual HccAlmacen Almacen { get; set; }
    }
}
