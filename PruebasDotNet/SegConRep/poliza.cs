//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SegConRep
{
    using System;
    using System.Collections.Generic;
    
    public partial class poliza
    {
        public poliza()
        {
            this.emisionevento = new HashSet<emisionevento>();
        }
    
        public string poliza_numero { get; set; }
        public int poliza_producto_1 { get; set; }
        public int poliza_producto_2 { get; set; }
        public Nullable<int> poliza_zona { get; set; }
        public Nullable<int> poliza_oficina { get; set; }
        public Nullable<int> poliza_estado_id { get; set; }
    
        public virtual ICollection<emisionevento> emisionevento { get; set; }
        public virtual polizaestado polizaestado { get; set; }
    }
}
