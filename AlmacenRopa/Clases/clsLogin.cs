using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmacenRopa.Clases
{
    public class clsLogin
    {
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; } = new LoginRespuesta();
        public ALMACEN_ROPAEntities db = new ALMACEN_ROPAEntities();

        private bool ValidarUsuario()
        {
            // Corrected property name from USUARIO to USUARIO1 based on the USUARIO class definition
            var usuario = db.USUARIOs.FirstOrDefault(u => u.USUARIO1 == login.Usuario);
            if (usuario == null)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = "Usuario no existe";
                return false;
            }
            return true;
        }

        private bool ValidarClave()
        {
            // Corrected property name from USUARIO to USUARIO1 based on the USUARIO class definition
            var usuario = db.USUARIOs.FirstOrDefault(u =>
                u.USUARIO1 == login.Usuario && u.CONTRASENA == login.Clave);

            // Validación con Bcrypt
            bool claveValida = BCrypt.Net.BCrypt.Verify(login.Clave, usuario.CONTRASENA);

            if (!claveValida)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = "Clave incorrecta";
                return false;
            }


            loginRespuesta.IdUsuario = usuario.ID_USUARIO;
            loginRespuesta.Usuario = usuario.USUARIO1; // Corrected property name
            loginRespuesta.Rol = usuario.ROL;
            return true;
        }

        public LoginRespuesta Ingresar()
        {
            try
            {
                if (ValidarUsuario() && ValidarClave())
                {
                    string token = TokenGenerator.GenerateTokenJwt(login.Usuario);

                    loginRespuesta.Autenticado = true;
                    loginRespuesta.Token = token;
                    loginRespuesta.Mensaje = "Autenticación exitosa";
                }

                return loginRespuesta;
            }
            catch (Exception ex)
            {
                return new LoginRespuesta
                {
                    Autenticado = false,
                    Mensaje = "Error en servidor: " + ex.Message
                };
            }
        }
    }
    public class Login
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }

    public class LoginRespuesta
    {
        public string Usuario { get; set; }
        public string Rol { get; set; }
        public bool Autenticado { get; set; }
        public int IdUsuario { get; set; }
        public string Token { get; set; }
        public string Mensaje { get; set; }
    }
}