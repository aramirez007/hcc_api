using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HCC_API_ADRIAN_RAMIREZ_SALAZAR.Data;
using HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace HCC_API_ADRIAN_RAMIREZ_SALAZAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdenesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Obtener el número total de órdenes y en qué mesa están
        [HttpGet("total-ordenes")]
        public ActionResult<ApiResponse> GetTotalOrdenes()
        {
            try
            {
                var totalOrdenes = _context.HccOrdenes
                    .GroupBy(o => o.mes_id)
                    .Select(g => new
                    {
                        MesaId = g.Key,
                        TotalOrdenes = g.Count()
                    }).ToList();

                if (totalOrdenes.Count == 0)
                {
                    return new ApiResponse("No se encontraron órdenes.", false);
                }

                return new ApiResponse($"Total de órdenes: {totalOrdenes.Count}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse($"Error al obtener las órdenes: {ex.Message}", true));
            }
        }

        // Endpoint 2: Obtener el número total de mesas disponibles y la cantidad de lugares por mesa
        [HttpGet("mesas-disponibles")]
        public ActionResult<ApiResponse> GetMesasDisponibles()
        {
            try
            {
                var mesasDisponibles = _context.HccMesas
                    .Where(m => m.mes_disponibles > 0)
                    .Select(m => new
                    {
                        MesaId = m.mes_id,
                        Lugares = m.mes_lugares
                    }).ToList();

                if (mesasDisponibles.Count == 0)
                {
                    return new ApiResponse("No hay mesas disponibles.", false);
                }

                return new ApiResponse("Mesas disponibles obtenidas con éxito.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse($"Error al obtener las mesas disponibles: {ex.Message}", true));
            }
        }

        // Endpoint 3: Insertar una nueva orden
        [HttpPost("crear-orden")]
        public async Task<ActionResult<ApiResponse>> CrearOrden([FromBody] OrdenRequest ordenRequest)
        {
            try
            {
                if (ordenRequest == null || ordenRequest.NuevaOrden == null || ordenRequest.OrdenDetalles == null || !ordenRequest.OrdenDetalles.Any())
                {
                    return BadRequest(new ApiResponse("Datos de orden inválidos.", false));
                }

                var nuevaOrden = ordenRequest.NuevaOrden;
                _context.HccOrdenes.Add(nuevaOrden);
                await _context.SaveChangesAsync();

                //Asignamos los detalles de la orden a la nueva orden
                foreach (var detalle in ordenRequest.OrdenDetalles) { 
                    detalle.ord_id = nuevaOrden.ord_id;
                    _context.HccOrdenDetalles.Add(detalle);
                }

                await _context.SaveChangesAsync();

                return new ApiResponse("Orden creada exitosamente!");

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse($"Error al crear la orden: {ex.Message}", true));
            }
        }

        // Endpoint 4: Actualizar orden (agregar nuevo producto)
        [HttpPut("agregar-producto/{ordenId}")]
        public async Task<ActionResult<ApiResponse>> AgregarProducto(int ordenId, [FromBody] HccOrdenDetalle detalleOrden)
        {
            try
            {
                var ordenExistente = await _context.HccOrdenes
                    .Include(o => o.OrdenDetalles)
                    .FirstOrDefaultAsync(o => o.ord_id == ordenId);

                if (ordenExistente == null)
                {
                    return NotFound(new ApiResponse("Orden no encontrada.", false));
                }

                _context.HccOrdenDetalles.Add(detalleOrden);
                await _context.SaveChangesAsync();

                return new ApiResponse("Producto agregado a la orden exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse($"Error al agregar el producto a la orden: {ex.Message}", true));
            }
        }

        // Endpoint 5: Actualizar orden (cambiar estatus)
        [HttpPut("actualizar-estatus/{ordenId}")]
        public async Task<ActionResult<ApiResponse>> ActualizarEstatus(int ordenId, [FromBody] int nuevoEstatus)
        {
            try
            {
                var ordenExistente = await _context.HccOrdenes
                    .FirstOrDefaultAsync(o => o.ord_id == ordenId);

                if (ordenExistente == null)
                {
                    return NotFound(new ApiResponse("Orden no encontrada.", false));
                }

                ordenExistente.ord_estatus = (byte)nuevoEstatus;
                await _context.SaveChangesAsync();

                return new ApiResponse("Estatus de la orden actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse($"Error al actualizar el estatus de la orden: {ex.Message}", true));
            }
        }

        // Endpoint 6: Eliminar orden (borrado lógico)
        [HttpDelete("eliminar-orden/{ordenId}")]
        public async Task<ActionResult<ApiResponse>> EliminarOrden(int ordenId)
        {
            try
            {
                var ordenExistente = await _context.HccOrdenes
                    .FirstOrDefaultAsync(o => o.ord_id == ordenId);

                if (ordenExistente == null)
                {
                    return NotFound(new ApiResponse("Orden no encontrada.", false));
                }

                // Realizando un borrado lógico (cambiar el estatus de la orden a 'eliminada' o algo similar)
                ordenExistente.ord_estatus = 0;  // Asumiendo 0 es el código de "eliminada"
                await _context.SaveChangesAsync();

                return new ApiResponse("Orden eliminada correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse($"Error al eliminar la orden: {ex.Message}", true));
            }
        }
    }
}
