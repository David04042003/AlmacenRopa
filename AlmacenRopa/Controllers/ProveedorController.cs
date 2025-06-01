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

        [RoutePrefix("api/Proveedor")]
        public class ProveedorController : ApiController
        {
            // Listar todos los proveedores
            [HttpGet]
            [Route("ListarProveedores")]
            public List<PROVEEDOR> ListarProveedores()
            {
                clsProveedor proveedor = new clsProveedor();
                return proveedor.ListarProveedores();
            }

            // Registrar un nuevo pedido (con detalles)
            [HttpPost]
            [Route("RegistrarPedido")]
            public string RegistrarPedido([FromBody] PedidoRequest pedido)
            {
                clsProveedor proveedor = new clsProveedor();
                return proveedor.RegistrarPedido(pedido);
            }

            // Consultar pedidos por proveedor
            [HttpGet]
            [Route("ConsultarPedidosPorProveedor")]
            public List<PEDIDO> ConsultarPedidosPorProveedor(int idProveedor)
            {
                clsProveedor proveedor = new clsProveedor();
                return proveedor.ObtenerPedidosPorProveedor(idProveedor);
            }

            // Consultar detalles de un pedido
            [HttpGet]
            [Route("ConsultarDetallesPedido")]
            public List<DETALLEPEDIDO> ConsultarDetallesPedido(int idPedido)
            {
                clsProveedor proveedor = new clsProveedor();
                return proveedor.ObtenerDetallePedido(idPedido);
            }

            // Cambiar estado de un pedido (true = recibido)
            [HttpPut]
            [Route("CambiarEstadoPedido")]
            public string CambiarEstadoPedido(int idPedido, bool estado)
            {
                clsProveedor proveedor = new clsProveedor();
                return proveedor.CambiarEstadoPedido(idPedido, estado);
            }
        }
    }
