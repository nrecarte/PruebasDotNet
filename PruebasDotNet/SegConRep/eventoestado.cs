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
    
    public partial class eventoestado
    {
        public eventoestado()
        {
            this.emisionevento = new HashSet<emisionevento>();
        }
    
        public int eventoestado_id { get; set; }
        public string eventoestado_estado { get; set; }
        public string eventoestado_descripcion { get; set; }
    
        public virtual ICollection<emisionevento> emisionevento { get; set; }
    }
}