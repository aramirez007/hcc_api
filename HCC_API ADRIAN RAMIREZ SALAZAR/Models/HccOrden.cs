namespace HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models
{
    public class HccOrden
    {
        public int ord_id { get; set; }
        public int mes_id { get; set; }
        public int catord_id { get; set; }
        public DateTime ord_fecha_inicio { get; set; }
        public byte ord_estatus { get; set; }
        public virtual HccMesa Mesas { get; set; }
        public virtual HccCatEstatusOrden EstatusOrden { get; set; }
        public virtual ICollection<HccOrdenDetalle>OrdenDetalles { get; set; }
    }
}
