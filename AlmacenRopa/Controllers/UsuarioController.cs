using AlmacenRopa.Clases;
using AlmacenRopa.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace AlmacenRopa.Controllers
{
    [RoutePrefix("api/Usuario")]
    [Authorize] // Requiere autenticación con token
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("Registrar")]
        public string Registrar([FromBody] USUARIO usuario)
        {
            clsUsuario cls = new clsUsuario();
            cls.usuario = usuario;
            return cls.Registrar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] USUARIO usuario)
        {
            clsUsuario cls = new clsUsuario();
            cls.usuario = usuario;
            return cls.Actualizar();
        }

        [HttpGet]
        [Route("consultarTodos")]
        public List<USUARIO> ConsultarTodos()
        {
            clsUsuario cls = new clsUsuario();
            return cls.ConsultarTodo();
        }

        [HttpDelete]
        [Route("EliminarPorId")]
        public string EliminarPorId(int idUsuario)
        {
            clsUsuario cls = new clsUsuario();
            return cls.Eliminar(idUsuario);
        }

    }
}