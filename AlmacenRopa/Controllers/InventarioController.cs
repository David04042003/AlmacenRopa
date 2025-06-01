using AlmacenRopa.Clases;
using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlmacenRopa.Controllers
{
    [RoutePrefix("api/Inventario")]
    [Authorize] // Requiere autenticación con token
    public class InventarioController : ApiController
    {
        // 1. Consultar stock por sede y/o producto
        [HttpGet]
        [Route("ConsultarStock")]
        public List<STOCK> ConsultarStock(int? idSede = null, int? idProductoVariante = null)
        {
            clsInventario inventario = new clsInventario();
            return inventario.ConsultarStock(idSede, idProductoVariante);
        }

        // 2. Actualizar cantidad de stock
        [HttpPut]
        [Route("ActualizarCantidad")]
        public string ActualizarCantidad([FromBody] StockRequestModel request)
        {
            clsInventario inventario = new clsInventario();
            return inventario.ActualizarCantidadStock(request.IdStock, request.NuevaCantidad);
        }

        // 3. Transferir stock entre sedes
        [HttpPost]
        [Route("TransferirStock")]
        public string TransferirStock([FromBody] TransferenciaStockModel request)
        {
            clsInventario inventario = new clsInventario();
            return inventario.TransferirStock(
                request.IdProductoVariante,
                request.IdSedeOrigen,
                request.IdSedeDestino,
                request.Cantidad
            );
        }
    }

    // DTOs para solicitudes POST/PUT
    public class StockRequestModel
    {
        public int IdStock { get; set; }
        public int NuevaCantidad { get; set; }
    }

    public class TransferenciaStockModel
    {
        public int IdProductoVariante { get; set; }
        public int IdSedeOrigen { get; set; }
        public int IdSedeDestino { get; set; }
        public int Cantidad { get; set; }
    }
}
