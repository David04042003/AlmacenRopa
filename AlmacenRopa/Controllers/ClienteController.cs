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
    [RoutePrefix("api/Clientes")]
    public class ClienteController : ApiController
    {
        //Buscar Cliente 
        [HttpPost]
        [Route("Registrar")]
        public string RegistrarCliente([FromBody] CLIENTE nuevoCliente)
        {
            clsCliente cls = new clsCliente();
            cls.cliente = nuevoCliente;
            return cls.InsertarCliente();
        }

        [HttpGet]
        [Route("Buscar")]
        public List<CLIENTE> BuscarClientes(string nombre= null, int? tipocliente= null)
        {
            clsCliente cls = new clsCliente();
            return cls.BuscarClientes(nombre, tipocliente);
        }

        //Historial
        [HttpGet]
        [Route("HistorialCompras")]
        public List<VENTA> ObtenerHistorialCompras(int idCliente)
        {
            clsCliente cls = new clsCliente();
            return cls.ObtenerHistorialCompras(idCliente);
        }

        [HttpGet]
        [Route("ConsultarTodo")]
        public List<CLIENTE> ConsultarTodos()
        {
            clsCliente cls = new clsCliente();
            return cls.ConsultarTodo();
        }

    }
}