using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AlmacenRopa.Clases
{
    public class clsCatalogo
    {
        private ALMACEN_ROPAEntities dbAlmacen = new ALMACEN_ROPAEntities();
        public PRODUCTO producto { get; set; }

        public string Insertar()
        {
            try
            {
                dbAlmacen.PRODUCTOes.Add(producto);
                dbAlmacen.SaveChanges();
                return "Producto insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el producto: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                PRODUCTO prod = ConsultarPorId(producto.ID_PRODUCTO); 
                if (prod == null)
                {
                    return "Producto no existe";
                }

                dbAlmacen.PRODUCTOes.AddOrUpdate(producto);
                dbAlmacen.SaveChanges();
                return "Producto actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el producto: " + ex.Message;
            }
        }

        private bool Validar(int ID_PRODUCTO)
        {
            return ConsultarPorId(ID_PRODUCTO) != null;
        }

        public PRODUCTO ConsultarPorId(int productoId)
        {
            PRODUCTO prod = dbAlmacen.PRODUCTOes.FirstOrDefault(p => p.ID_PRODUCTO == productoId); 
            return prod;
        }

        public string Eliminar()
        {
            try
            {
                PRODUCTO prod = ConsultarPorId(producto.ID_PRODUCTO); 
                if (prod == null)
                {
                    return "Producto no existe";
                }

                dbAlmacen.PRODUCTOes.Remove(prod);
                dbAlmacen.SaveChanges();
                return "Producto eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el producto: " + ex.Message;
            }
        }

        public string EliminarPorId(int ID_PRODUCTO)
        {
            try
            {
                PRODUCTO prod = ConsultarPorId(ID_PRODUCTO);
                if (prod == null)
                {
                    return "Producto no existe";
                }

                dbAlmacen.PRODUCTOes.Remove(prod);
                dbAlmacen.SaveChanges();
                return "Producto eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el producto: " + ex.Message;
            }
        }

        public List<PRODUCTO> ConsultarTodos()
        {
            return dbAlmacen.PRODUCTOes
                .OrderBy(p => p.NOMBRE) 
                .ToList();
        }

        public List<PRODUCTO> ObtenerProductosPorCategoria(int categoriaId)
        {
            return dbAlmacen.PRODUCTOes
                .Where(p => p.ID_CATEGORIA == categoriaId) 
                .OrderBy(p => p.NOMBRE) 
                .ToList();
        }

        public List<PRODUCTO> BusquedaAvanzada(string talla = null, string color = null, decimal? precioMin = null, decimal? precioMax = null, string nombre = null)
        {
            var query = dbAlmacen.PRODUCTOes.AsQueryable();

            if (!string.IsNullOrEmpty(talla))
            {
                // Necesitamos un join con PRODUCTO_VARIANTE y TALLA
                query = query.Where(p => p.PRODUCTO_VARIANTE.Any(pv => pv.TALLA.DESCRIPCION == talla));
            }

            if (!string.IsNullOrEmpty(color))
            {
                // Necesitamos un join con PRODUCTO_VARIANTE y COLOR
                query = query.Where(p => p.PRODUCTO_VARIANTE.Any(pv => pv.COLOR.NOMBRE_COLOR == color));
            }

            if (precioMin.HasValue)
            {
                query = query.Where(p => p.PRECIO_BASE >= precioMin.Value); 
            }

            if (precioMax.HasValue)
            {
                query = query.Where(p => p.PRECIO_BASE <= precioMax.Value); 
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.NOMBRE.Contains(nombre)); 
            }

            return query.OrderBy(p => p.NOMBRE).ToList(); 
        }

        public List<PRODUCTO> ObtenerProductosRelacionados(int ID_PRODUCTO)
        {
            var productoActual = ConsultarPorId(ID_PRODUCTO);

            if (productoActual == null)
            {
                return new List<PRODUCTO>();
            }

            var productosRelacionados = dbAlmacen.PRODUCTOes
                .Where(p => p.ID_CATEGORIA == productoActual.ID_CATEGORIA && p.ID_PRODUCTO != ID_PRODUCTO) 
                .OrderBy(p => Guid.NewGuid())
                .Take(5)
                .ToList();

            return productosRelacionados;
        }

        public List<CATEGORIA> ObtenerCategorias()
        {
            return dbAlmacen.CATEGORIAs
                .OrderBy(c => c.NOMBRE) 
                .ToList();
        }

        public List<string> ObtenerColoresDisponibles()
        {
            return dbAlmacen.COLORs
                .Select(c => c.NOMBRE_COLOR) 
                .Distinct()
                .OrderBy(c => c)
                .ToList();
        }

        public List<string> ObtenerTallasDisponibles()
        {
            return dbAlmacen.TALLAs
                .Select(t => t.DESCRIPCION) 
                .Distinct()
                .OrderBy(t => t)
                .ToList();
        }
    }
}