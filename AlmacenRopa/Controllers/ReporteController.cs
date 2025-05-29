using AlmacenRopa.Clases;
using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlmacenRopa.Controllers
{
    [RoutePrefix("api/Reporte")]
    [Authorize] // Requiere autenticación con token
    public class ReporteController : ApiController
    {
        [HttpGet]
        [Route("VentasPorPeriodo")]
        public List<VENTA> VentasPorPeriodo(DateTime fechaInicio, DateTime fechaFin, int? idSede = null)
        {
            clsReporte reporte = new clsReporte();
            return reporte.VentaPorPeriodo(fechaInicio, fechaFin, idSede);
        }

        [HttpGet]
        [Route("PorductoMasVendido")]
        public List<object> ProductoMasVendido()
        {
            clsReporte reporte = new clsReporte();
            return reporte.ObtenerProductoMasVendido();
        }

        [HttpGet]
        [Route("StockCritico")]
        public List<STOCK> StockCritico(int umbral = 10)
        {
            clsReporte reporte = new clsReporte();
            return reporte.ObtenerStockCritico(umbral);
        }
    }
}
