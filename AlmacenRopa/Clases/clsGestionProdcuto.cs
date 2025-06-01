using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AlmacenRopa.Clases
{
    public class clsGestionProdcuto
    {
        private ALMACEN_ROPAEntities dbAlmacen = new ALMACEN_ROPAEntities();

        // Listar Producto
        public List<PRODUCTO> ListarProdcutosFiltrados(int? categoriaId = null, decimal? precioMin = null, decimal? precioMax = null)
        {
            var query = dbAlmacen.PRODUCTOes.AsQueryable();
            if (categoriaId.HasValue)
                query = query.Where(p => p.ID_CATEGORIA == categoriaId.Value);
            if (precioMin.HasValue)
                query = query.Where(p => p.PRECIO_BASE >= precioMin.Value);
            if (precioMax.HasValue)
                query = query.Where(p => p.PRECIO_BASE <= precioMax.Value);

            return query.OrderBy(p => p.NOMBRE).ToList();
        }

        // Obtener detalles de producto con variantes
        public PRODUCTO ObtenerDetallesProducto(int idProdcuto)
        {
            return dbAlmacen.PRODUCTOes.FirstOrDefault(p => p.ID_PRODUCTO == idProdcuto);
        }

        public List<PRODUCTO_VARIANTE> ObtenerVariantesPorProducto (int idProdcuto)
        {
            return dbAlmacen.PRODUCTO_VARIANTE
                .Where(V => V.ID_PRODUCTO == idProdcuto)
                .ToList();
        }
    }
}