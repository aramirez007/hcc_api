namespace HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models
{
    public class HccOrdenDetalle
    {
        public int orddet_id { get; set; }
        public int ord_id { get; set; }
        public int pro_id { get; set; }
        public short orddet_cantidad { get; set; }
        public byte orddet_estatus { get; set; }

        public virtual HccOrden Orden { get; set; }
        public virtual HccProducto Producto { get; set; }
    }
}
