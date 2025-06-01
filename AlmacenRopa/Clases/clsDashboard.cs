using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmacenRopa.Clases
{
    public class clsDashboard
    {
            private ALMACEN_ROPAEntities db = new ALMACEN_ROPAEntities();

            // Totales
            public int ObtenerTotalVentas()
            {
                return db.VENTAS.Count();
            }

            public int ObtenerTotalDevoluciones()
            {
                return db.DEVOLUCIONs.Count();
            }

            public int ObtenerTotalPedidos()
            {
                return db.PEDIDOes.Count();
            }

            // Ventas por día
            public List<object> ObtenerVentasPorDia()
            {
                var resultado = db.VENTAS
                    .GroupBy(v => v.FECHA.Date)
                    .Select(g => new {
                        Fecha = g.Key,
                        TotalVentas = g.Count()
                    }).ToList<object>();

                return resultado;
            }

            // Productos más vendidos
            public List<object> ObtenerProductosMasVendidos()
            {
                var resultado = db.DETALLEVENTAs
                    .GroupBy(d => d.STOCK)
                    .Select(g => new {
                        Producto = g.FirstOrDefault().STOCK.PRODUCTO_VARIANTE,
                        CantidadVendida = g.Sum(d => d.CANTIDAD)
                    })
                    .OrderByDescending(x => x.CantidadVendida)
                    .Take(10)
                    .ToList<object>();

                return resultado;
            }

            // Alertas
            public List<PEDIDO> ObtenerPedidosPendientes()
            {
                return db.PEDIDOes.Where(p => p.ESTADO == false).ToList();
            }

            public List<object> ObtenerProductosConStockBajo(int limite = 5)
            {
                return db.STOCKs
                    .Where(s => s.CANTIDAD <= limite)
                    .Select(s => new {
                        Producto = s.PRODUCTO_VARIANTE.PRODUCTO.NOMBRE,
                        Variante = s.PRODUCTO_VARIANTE.PRODUCTO,
                        Stock = s.CANTIDAD
                    }).ToList<object>();
            }

            // Resumen
            public int ObtenerTotalClientes()
            {
                return db.CLIENTES.Count();
            }

            public int ObtenerTotalProductos()
            {
                return db.PRODUCTO_VARIANTE.Count();
            }
        }
    }
