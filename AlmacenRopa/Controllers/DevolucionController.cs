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
        [RoutePrefix("api/Devoluciones")]
        public class DevolucionController : ApiController
        {
            // Consultar todas
            [HttpGet]
            [Route("ConsultarTodas")]
            public List<DEVOLUCION> ConsultarTodas()
            {
                clsDevoluciones devolucion = new clsDevoluciones();
                return devolucion.ConsultarTodas();
            }

            // Consultar por ID
            [HttpGet]
            [Route("ConsultarPorId")]
            public DEVOLUCION ConsultarPorId(int id)
            {
                clsDevoluciones devolucion = new clsDevoluciones();
                return devolucion.ConsultarPorId(id);
            }

            // Insertar
            [HttpPost]
            [Route("Insertar")]
            public string Insertar([FromBody] DEVOLUCION obj)
            {
                clsDevoluciones devolucion = new clsDevoluciones();
                devolucion.devolucion = obj;
                return devolucion.Insertar();
            }

            // Actualizar
            [HttpPut]
            [Route("Actualizar")]
            public string Actualizar([FromBody] DEVOLUCION obj)
            {
                clsDevoluciones devolucion = new clsDevoluciones();
                devolucion.devolucion = obj;
                return devolucion.Actualizar();
            }

            // Eliminar por objeto
            [HttpDelete]
            [Route("Eliminar")]
            public string Eliminar([FromBody] DEVOLUCION obj)
            {
                clsDevoluciones devolucion = new clsDevoluciones();
                devolucion.devolucion = obj;
                return devolucion.Eliminar();
            }

            // Eliminar por ID
            [HttpDelete]
            [Route("EliminarPorId")]
            public string EliminarPorId(int id)
            {
                clsDevoluciones devolucion = new clsDevoluciones();
                return devolucion.EliminarPorId(id);
            }
        }
    }
