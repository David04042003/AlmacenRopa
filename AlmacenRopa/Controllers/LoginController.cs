using AlmacenRopa.Clases;
using System;
using System.Linq;
using System.Web.Http;


namespace AlmacenRopa.Controllers
{
    [RoutePrefix("api/Login")]
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public IHttpActionResult Ingresar([FromBody] Login login)
        {
            try
            {
                clsLogin cls = new clsLogin();
                cls.login = login;

                var respuesta = cls.Ingresar();

                return Ok(respuesta); // Correctly returning IHttpActionResult
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); // Returning the error as IHttpActionResult
            }
        }
    }
}