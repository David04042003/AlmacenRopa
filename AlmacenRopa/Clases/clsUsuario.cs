using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using BCrypt.Net;

namespace AlmacenRopa.Clases
{
    public class clsUsuario
    {
        public USUARIO usuario { get; set; }
        public ALMACEN_ROPAEntities dbAlmacen = new ALMACEN_ROPAEntities();

        public string Registrar()
        {
            try
            {
                usuario.CONTRASENA = BCrypt.Net.BCrypt.HashPassword(usuario.CONTRASENA);
                dbAlmacen.USUARIOs.Add(usuario);
                dbAlmacen.SaveChanges();
                return "Usuario Ingresado Correctamente";
            }
            catch(Exception ex)
            {
                return "Error al Ingresar el Usuario: " +ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                var user = dbAlmacen.USUARIOs.FirstOrDefault(u => u.ID_USUARIO == usuario.ID_USUARIO);
                if(user == null)
                
                    return "Usuario no encontrado";
                user.USUARIO1 = usuario.USUARIO1;
                user.ROL = usuario.ROL;
                user.ID_EMPLEADO = usuario.ID_EMPLEADO;
                //Si se desea actualizar la contraseña, la encripta BCrypt
                if (!string.IsNullOrWhiteSpace(usuario.CONTRASENA))
                {
                    user.CONTRASENA = BCrypt.Net.BCrypt.HashPassword(usuario.CONTRASENA);
                }
                dbAlmacen.SaveChanges();
                return "Usuario Actualizado Conrrectamente";
                
            }
            catch(Exception ex)
            {
                return "Error al Actualizar el  Usuario: " + ex.Message;
            }
        }

        public string Eliminar(int idUsaurio)
        {
            try
            {
                var user = dbAlmacen.USUARIOs.FirstOrDefault(v => v.ID_USUARIO == idUsaurio);
                if (user == null)
                    return "Usuario no Encontrado";

                dbAlmacen.USUARIOs.Remove(user);
                dbAlmacen.SaveChanges();
                return "Usuario Eliminado Correctamente";
            }
            catch(Exception ex)
            {
                return "Error al Eliminar el Usuario: " + ex.Message;
            }
        }

        public List<USUARIO> ConsultarTodo()
        {
            return dbAlmacen.USUARIOs.ToList();
        }



    }
}