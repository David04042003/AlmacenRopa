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

        [RoutePrefix("api/dashboard")]
        public class DashboardController : ApiController
        {
            clsDashboard dashboard = new clsDashboard();

            [HttpGet]
            [Route("TotalVentas")]
            public int TotalVentas() => dashboard.ObtenerTotalVentas();

            [HttpGet]
            [Route("TotalDevoluciones")]
            public int TotalDevoluciones() => dashboard.ObtenerTotalDevoluciones();

            [HttpGet]
            [Route("TotalPedidos")]
            public int TotalPedidos() => dashboard.ObtenerTotalPedidos();

            [HttpGet]
            [Route("VentasPorDia")]
            public List<object> VentasPorDia() => dashboard.ObtenerVentasPorDia();

            [HttpGet]
            [Route("ProductosMasVendidos")]
            public List<object> ProductosMasVendidos() => dashboard.ObtenerProductosMasVendidos();

            [HttpGet]
            [Route("PedidosPendientes")]
            public List<PEDIDO> PedidosPendientes() => dashboard.ObtenerPedidosPendientes();

            [HttpGet]
            [Route("ProductosConStockBajo")]
            public List<object> ProductosConStockBajo() => dashboard.ObtenerProductosConStockBajo();

            [HttpGet]
            [Route("TotalClientes")]
            public int TotalClientes() => dashboard.ObtenerTotalClientes();

            [HttpGet]
            [Route("TotalProductos")]
            public int TotalProductos() => dashboard.ObtenerTotalProductos();
        }
    }
