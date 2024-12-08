using HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models;

namespace HCC_API_ADRIAN_RAMIREZ_SALAZAR.Controllers
{
    public class OrdenRequest
    {
        public HccOrden NuevaOrden { get; set; }
        public List<HccOrdenDetalle> OrdenDetalles { get; set; }
    }
}
