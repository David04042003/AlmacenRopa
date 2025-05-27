using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlmacenRopa.Clases
{
    public class clsCliente
    {
        private ALMACEN_ROPAEntities dbAlmacen = new ALMACEN_ROPAEntities();
        public CLIENTE cliente { get; set; }

        // Registrar nuevo cliente
        public string InsertarCliente()
        {
            try
            {
                dbAlmacen.CLIENTES.Add(cliente);
                dbAlmacen.SaveChanges();
                return "Cliente registrado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al registrar cliente: " + ex.Message;
            }
        }
        // Buscar clientes por nombre o tipo
        public List<CLIENTE> BuscarClientes(string nombre = null, int? tipoCliente = null)
        {
            var query = dbAlmacen.CLIENTES.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(c => c.NOMBRE.Contains(nombre));

            if (tipoCliente.HasValue)
                query = query.Where(c => c.TIPO_CLIENTE == tipoCliente);

            return query.OrderBy(c => c.NOMBRE).ToList();
        }

        public List<CLIENTE> ConsultarTodo()
        {
            return dbAlmacen.CLIENTES.OrderBy(c => c.NOMBRE).ToList();

        }
        // Historial de compras por cliente
        public List<VENTA> ObtenerHistorialCompras(int idCliente)
        {
            return dbAlmacen.VENTAS
                .Where(v => v.ID_CLIENTE == idCliente)
                .OrderByDescending(v => v.FECHA)
                .ToList();
        }

    }
}