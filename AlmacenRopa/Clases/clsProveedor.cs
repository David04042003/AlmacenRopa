using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmacenRopa.Clases
{

        public class clsProveedor
        {
            private ALMACEN_ROPAEntities db = new ALMACEN_ROPAEntities();

            public PROVEEDOR proveedor { get; set; }
            public PEDIDO pedido { get; set; }
            public List<DETALLEPEDIDO> detallesPedido { get; set; }

            // Listar todos los proveedores
            public List<PROVEEDOR> ListarProveedores()
            {
                return db.PROVEEDORs.ToList();
            }

        // Registrar un nuevo pedido con sus detalles

            public string RegistrarPedido(PedidoRequest request)
            {
                try
                {
                    using (var db = new ALMACEN_ROPAEntities())
                    {
                        var pedido = request.Pedido;
                        db.PEDIDOes.Add(pedido);
                        db.SaveChanges();

                        foreach (var detalle in request.Detalles)
                        {
                            detalle.ID_PEDIDO = pedido.ID_PEDIDO;
                            db.DETALLEPEDIDOes.Add(detalle);
                        }

                        db.SaveChanges();
                        return "Pedido registrado correctamente.";
                    }
                }
                catch (Exception ex)
                {
                    return "Error al registrar el pedido: " + ex.Message;
                }
            }
        


        // Consultar pedidos por proveedor
        public List<PEDIDO> ObtenerPedidosPorProveedor(int idProveedor)
            {
                return db.PEDIDOes.Where(p => p.ID_PROVEEDOR == idProveedor).ToList();
            }

            // Consultar detalles de un pedido
            public List<DETALLEPEDIDO> ObtenerDetallePedido(int idPedido)
            {
                return db.DETALLEPEDIDOes.Where(dp => dp.ID_PEDIDO == idPedido).ToList();
            }

            // Cambiar el estado de un pedido
            public string CambiarEstadoPedido(int idPedido, bool nuevoEstado)
            {
                try
                {
                    var pedidoExistente = db.PEDIDOes.FirstOrDefault(p => p.ID_PEDIDO == idPedido);
                    if (pedidoExistente == null)
                        return "Pedido no encontrado.";

                    pedidoExistente.ESTADO = nuevoEstado;
                    db.SaveChanges();
                    return "Estado del pedido actualizado.";
                }
                catch (Exception ex)
                {
                    return "Error al cambiar estado del pedido: " + ex.Message;
                }
            }
        }
    public class PedidoRequest
    {
        public PEDIDO Pedido { get; set; }
        public List<DETALLEPEDIDO> Detalles { get; set; }
    }

}
