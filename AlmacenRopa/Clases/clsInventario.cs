using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlmacenRopa.Clases
{
    public class clsInventario
    {
        private ALMACEN_ROPAEntities db = new ALMACEN_ROPAEntities();

        // 1. Consultar stock por sede y/o producto
        public List<STOCK> ConsultarStock(int? idSede = null, int? idProductoVariante = null)
        {
            var query = db.STOCKs.AsQueryable();

            if (idSede.HasValue)
                query = query.Where(s => s.ID_SEDE == idSede.Value);

            if (idProductoVariante.HasValue)
                query = query.Where(s => s.ID_PRODUCTO_VARIANTE == idProductoVariante.Value);

            return query.ToList();
        }

        // 2. Actualizar cantidades de inventario
        public string ActualizarCantidadStock(int idStock, int nuevaCantidad)
        {
            try
            {
                var stock = db.STOCKs.FirstOrDefault(s => s.ID_STOCK == idStock);
                if (stock == null)
                    return "Stock no encontrado.";

                if (nuevaCantidad < 0)
                    return "La cantidad no puede ser negativa.";

                stock.CANTIDAD = nuevaCantidad;
                db.SaveChanges();
                return "Cantidad actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar cantidad: " + ex.Message;
            }
        }

        // 3. Transferir stock entre sedes
        public string TransferirStock(int idProductoVariante, int idSedeOrigen, int idSedeDestino, int cantidad)
        {
            try
            {
                if (cantidad <= 0)
                    return "La cantidad a transferir debe ser mayor que 0.";

                var stockOrigen = db.STOCKs.FirstOrDefault(s => s.ID_PRODUCTO_VARIANTE == idProductoVariante && s.ID_SEDE == idSedeOrigen);
                if (stockOrigen == null || stockOrigen.CANTIDAD < cantidad)
                    return "Stock insuficiente en la sede de origen.";

                var stockDestino = db.STOCKs.FirstOrDefault(s => s.ID_PRODUCTO_VARIANTE == idProductoVariante && s.ID_SEDE == idSedeDestino);

                if (stockDestino == null)
                {
                    stockDestino = new STOCK
                    {
                        ID_PRODUCTO_VARIANTE = idProductoVariante,
                        ID_SEDE = idSedeDestino,
                        CANTIDAD = 0
                    };
                    db.STOCKs.Add(stockDestino);
                }

                stockOrigen.CANTIDAD -= cantidad;
                stockDestino.CANTIDAD += cantidad;

                db.SaveChanges();
                return "Transferencia realizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al transferir stock: " + ex.Message;
            }
        }
    }
}
