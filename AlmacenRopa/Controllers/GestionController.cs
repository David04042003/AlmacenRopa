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
    [RoutePrefix("api/GestionProducto")]
    [Authorize] // Requiere autenticación con token
    public class GestionController : ApiController
    {
        //Buscar Producto
        [HttpGet]
        [Route("Listar")]
        public List<PRODUCTO> ListarProducto(int? idCategoria = null, decimal? precioMin = null, decimal? precioMax = null)
        {
            clsGestionProdcuto gestion = new clsGestionProdcuto();
            return gestion.ListarProdcutosFiltrados(idCategoria, precioMin, precioMax);
        }
        [HttpGet]
        [Route("DetallesConVariantes")]
        public PRODUCTO ObtenerDetallesConVariantes(int idProducto)
        {
            clsGestionProdcuto gestion = new clsGestionProdcuto();
            return gestion.ObtenerDetallesProducto(idProducto);
        }
        [HttpGet]
        [Route("VariantesPorProducto")]
        public List<PRODUCTO_VARIANTE> VariantesPorPrODUCTO(int idProducto)
        {
            clsGestionProdcuto gestion = new clsGestionProdcuto();
            return gestion.ObtenerVariantesPorProducto(idProducto);
        }
    }
}