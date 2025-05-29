using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlmacenRopa.Clases
{
    public class clsReporte
    {
        private ALMACEN_ROPAEntities dbAlmacen = new ALMACEN_ROPAEntities();

        // 1. Consultar ventas por periodo y/o Sede
        public List<VENTA> VentaPorPeriodo(DateTime fechaInicio, DateTime fechaFin, int? idSede = null)
        {
            var query = dbAlmacen.VENTAS
                .Where(v => v.FECHA >= fechaInicio && v.FECHA <= fechaFin);
                if (idSede.HasValue)
                {
                     query = query.Where(v => v.EMPLEADO.ID_SEDE == idSede.Value);
                }
            return query.ToList();
        }

        // 2. Producto más vendido

        public List<object> ObtenerProductoMasVendido()
        {
            var result = dbAlmacen.DETALLEVENTAs
                .GroupBy(d => d.ID_STOCK)
                .Select(g => new
                {
                    IdStock = g.Key,
                    TotalVendido = g.Sum(x => x.CANTIDAD),
                    Producto = g.FirstOrDefault().STOCK.PRODUCTO_VARIANTE.PRODUCTO.NOMBRE,
                    Talla = g.FirstOrDefault().STOCK.PRODUCTO_VARIANTE.TALLA.DESCRIPCION,
                    Color = g.FirstOrDefault().STOCK.PRODUCTO_VARIANTE.COLOR.NOMBRE_COLOR

                })
                .OrderByDescending(X => X.TotalVendido)
                .Take(10)
                .ToList<object>();

            return result;
        }

        //Stock Critico
        public List<STOCK> ObtenerStockCritico(int umbral = 10)
        {
            return dbAlmacen.STOCKs
                .Where(s => s.CANTIDAD <= umbral)
                .OrderBy(s => s.CANTIDAD)
                .ToList();
        }
    }
}