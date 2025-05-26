using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AlmacenRopa.Clases
{
    public class clsVentas
    {
        private ALMACEN_ROPAEntities dbAlmacen = new ALMACEN_ROPAEntities();
        public VENTA venta { get; set; }

        public string Insertar()
        {
            try
            {
                dbAlmacen.VENTAS.Add(venta);
                dbAlmacen.SaveChanges();
                return "Venta registrada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al registrar la venta: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                VENTA v = ConsultarPorId(venta.ID_VENTA);
                if (v == null)
                {
                    return "Venta no encontrada";
                }

                dbAlmacen.VENTAS.AddOrUpdate(venta);
                dbAlmacen.SaveChanges();
                return "Venta actualizada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar la venta: " + ex.Message;
            }
        }

        public VENTA ConsultarPorId(int ventaId)
        {
            return dbAlmacen.VENTAS.FirstOrDefault(v => v.ID_VENTA == ventaId);
        }

        public string Eliminar()
        {
            try
            {
                VENTA v = ConsultarPorId(venta.ID_VENTA);
                if (v == null)
                {
                    return "Venta no encontrada";
                }

                dbAlmacen.VENTAS.Remove(v);
                dbAlmacen.SaveChanges();
                return "Venta eliminada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la venta: " + ex.Message;
            }
        }

        public string EliminarPorId(int ventaId)
        {
            try
            {
                VENTA v = ConsultarPorId(ventaId);
                if (v == null)
                {
                    return "Venta no encontrada";
                }

                dbAlmacen.VENTAS.Remove(v);
                dbAlmacen.SaveChanges();
                return "Venta eliminada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la venta: " + ex.Message;
            }
        }

        public List<VENTA> ConsultarTodas()
        {
            return dbAlmacen.VENTAS
                .ToList();
        }

        public List<VENTA> ObtenerVentasPorCliente(int clienteId)
        {
            return dbAlmacen.VENTAS
                .Where(v => v.ID_CLIENTE == clienteId)
                .ToList();
        }

        public List<VENTA> ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return dbAlmacen.VENTAS
                .Where(v => v.FECHA >= fechaInicio && v.FECHA <= fechaFin)
                .ToList();
        }
    }
}