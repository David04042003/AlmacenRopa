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
    [RoutePrefix("api/Catalogo")]
    public class CatalogoController : ApiController
    {
       
        // Método para consultar todos los productos
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<PRODUCTO> ConsultarTodos()
        {
            clsCatalogo catalogo = new clsCatalogo();
            return catalogo.ConsultarTodos();
        }

        // Método para consultar un producto por su ID
        [HttpGet]
        [Route("ConsultarPorId")]
        public PRODUCTO ConsultarPorId(int ID_PRODUCTOId)
        {
            clsCatalogo catalogo = new clsCatalogo();
            return catalogo.ConsultarPorId(ID_PRODUCTOId);
        }

        // Método para obtener productos por categoría
        [HttpGet]
        [Route("ProductosPorCategoria")]
        public List<PRODUCTO> ObtenerProductosPorCategoria(int categoriaId)
        {
            clsCatalogo catalogo = new clsCatalogo();
            return catalogo.ObtenerProductosPorCategoria(categoriaId);
        }

        // Método para la búsqueda avanzada
        [HttpGet]
        [Route("BusquedaAvanzada")]
        public List<PRODUCTO> BusquedaAvanzada(string talla = null, string color = null, decimal? precioMin = null, decimal? precioMax = null, string nombre = null)
        {
            clsCatalogo catalogo = new clsCatalogo();
            return catalogo.BusquedaAvanzada(talla, color, precioMin, precioMax, nombre);
        }

        // Método para obtener productos relacionados
        [HttpGet]
        [Route("ProductosRelacionados")]
        public List<PRODUCTO> ObtenerProductosRelacionados(int ID_PRODUCTO)
        {
            clsCatalogo catalogo = new clsCatalogo();
            return catalogo.ObtenerProductosRelacionados(ID_PRODUCTO);
        }

        // Método para obtener las categorías disponibles
        [HttpGet]
        [Route("Categorias")]
        public List<CATEGORIA> ObtenerCategorias()
        {
            clsCatalogo catalogo = new clsCatalogo();
            return catalogo.ObtenerCategorias();
        }

        // Método para obtener los colores disponibles
        [HttpGet]
        [Route("ColoresDisponibles")]
        public List<string> ObtenerColoresDisponibles()
        {
            clsCatalogo catalogo = new clsCatalogo();
            return catalogo.ObtenerColoresDisponibles();
        }

        // Método para obtener las tallas disponibles
        [HttpGet]
        [Route("TallasDisponibles")]
        public List<string> ObtenerTallasDisponibles()
        {
            clsCatalogo catalogo = new clsCatalogo();
            return catalogo.ObtenerTallasDisponibles();
        }

        // Método para insertar un producto
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PRODUCTO producto)
        {
            clsCatalogo catalogo = new clsCatalogo();
            catalogo.producto = producto;
            return catalogo.Insertar();
        }

        // Método para actualizar un producto
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PRODUCTO producto)
        {
            clsCatalogo catalogo = new clsCatalogo();
            catalogo.producto = producto;
            return catalogo.Actualizar();
        }

        // Método para eliminar un producto
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] PRODUCTO producto)
        {
            clsCatalogo catalogo = new clsCatalogo();
            catalogo.producto = producto;
            return catalogo.Eliminar();
        }

        // Método para eliminar un producto por su ID
        [HttpDelete]
        [Route("EliminarPorId")]
        public string EliminarPorId(int ID_PRODUCTO)
        {
            clsCatalogo catalogo = new clsCatalogo();
            return catalogo.EliminarPorId(ID_PRODUCTO);
        }
    }
}