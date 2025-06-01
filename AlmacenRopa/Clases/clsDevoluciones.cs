using AlmacenRopa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmacenRopa.Clases
{
    public class clsDevoluciones

        {
            private ALMACEN_ROPAEntities db = new ALMACEN_ROPAEntities();
            public DEVOLUCION devolucion { get; set; }

            // Consultar todas las devoluciones
            public List<DEVOLUCION> ConsultarTodas()
            {
                return db.DEVOLUCIONs.ToList();
            }

            // Consultar una devolución por ID
            public DEVOLUCION ConsultarPorId(int id)
            {
                return db.DEVOLUCIONs.Find(id);
            }

            // Insertar una devolución
            public string Insertar()
            {
                try
                {
                    db.DEVOLUCIONs.Add(devolucion);
                    db.SaveChanges();
                    return "Devolución registrada exitosamente.";
                }
                catch (Exception ex)
                {
                    return "Error al insertar devolución: " + ex.Message;
                }
            }

            // Actualizar una devolución
            public string Actualizar()
            {
                try
                {
                    var existente = db.DEVOLUCIONs.Find(devolucion.ID_DEVOLUCION);
                    if (existente != null)
                    {
                        db.Entry(existente).CurrentValues.SetValues(devolucion);
                        db.SaveChanges();
                        return "Devolución actualizada exitosamente.";
                    }
                    return "Devolución no encontrada.";
                }
                catch (Exception ex)
                {
                    return "Error al actualizar devolución: " + ex.Message;
                }
            }

            // Eliminar una devolución
            public string Eliminar()
            {
                try
                {
                    var existente = db.DEVOLUCIONs.Find(devolucion.ID_DEVOLUCION);
                    if (existente != null)
                    {
                        db.DEVOLUCIONs.Remove(existente);
                        db.SaveChanges();
                        return "Devolución eliminada exitosamente.";
                    }
                    return "Devolución no encontrada.";
                }
                catch (Exception ex)
                {
                    return "Error al eliminar devolución: " + ex.Message;
                }
            }

            // Eliminar por ID
            public string EliminarPorId(int id)
            {
                try
                {
                    var existente = db.DEVOLUCIONs.Find(id);
                    if (existente != null)
                    {
                        db.DEVOLUCIONs.Remove(existente);
                        db.SaveChanges();
                        return "Devolución eliminada exitosamente.";
                    }
                    return "Devolución no encontrada.";
                }
                catch (Exception ex)
                {
                    return "Error al eliminar devolución: " + ex.Message;
                }
            }
        }
    }
