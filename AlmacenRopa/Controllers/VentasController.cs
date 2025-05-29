using AlmacenRopa.Clases;
using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlmacenRopa.Controllers
{
    [RoutePrefix("api/Venta")]
    public class VentaController : ApiController
    {
        // Consultar todas las ventas
        [HttpGet]
        [Route("ConsultarTodas")]
        public List<VENTA> ConsultarTodas()
        {
            clsVentas venta = new clsVentas();
            return venta.ConsultarTodas();
        }

        // Consultar venta por ID
        [HttpGet]
        [Route("ConsultarPorId")]
        public VENTA ConsultarPorId(int ID_VENTA)
        {
            clsVentas venta = new clsVentas();
            return venta.ConsultarPorId(ID_VENTA);
        }

        // Obtener ventas por cliente
        [HttpGet]
        [Route("VentasPorCliente")]
        public List<VENTA> ObtenerVentasPorCliente(int ID_CLIENTE)
        {
            clsVentas venta = new clsVentas();
            return venta.ObtenerVentasPorCliente(ID_CLIENTE);
        }

        // Obtener ventas por fecha
        [HttpGet]
        [Route("VentasPorFecha")]
        public List<VENTA> ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            clsVentas venta = new clsVentas();
            return venta.ObtenerVentasPorFecha(fechaInicio, fechaFin);
        }

        // Insertar una nueva venta
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] VENTA nuevaVenta)
        {
            clsVentas venta = new clsVentas();
            venta.venta = nuevaVenta;
            return venta.Insertar();
        }

        // Actualizar venta existente
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] VENTA ventaActualizada)
        {
            clsVentas venta = new clsVentas();
            venta.venta = ventaActualizada;
            return venta.Actualizar();
        }

        // Eliminar venta por objeto
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] VENTA ventaAEliminar)
        {
            clsVentas venta = new clsVentas();
            venta.venta = ventaAEliminar;
            return venta.Eliminar();
        }

        // Eliminar venta por ID
        [HttpDelete]
        [Route("EliminarPorId")]
        public string EliminarPorId(int ID_VENTA)
        {
            clsVentas venta = new clsVentas();
            return venta.EliminarPorId(ID_VENTA);
        }
    }
}