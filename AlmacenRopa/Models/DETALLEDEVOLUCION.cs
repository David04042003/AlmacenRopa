//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlmacenRopa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETALLEDEVOLUCION
    {
        public int ID_DETALLE_DEV { get; set; }
        public int CANTIDAD { get; set; }
        public int ID_DEVOLUCION { get; set; }
        public int ID_DETALLE { get; set; }
    
        public virtual DETALLEVENTA DETALLEVENTA { get; set; }
        public virtual DEVOLUCION DEVOLUCION { get; set; }
    }
}
