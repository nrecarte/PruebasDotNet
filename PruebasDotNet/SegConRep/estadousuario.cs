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
    
    public partial class estadousuario
    {
        public estadousuario()
        {
            this.usuario = new HashSet<usuario>();
        }
    
        public int estadousuario_id { get; set; }
        public string estadousuario_estado { get; set; }
        public string estadousuario_descripcion { get; set; }
    
        public virtual ICollection<usuario> usuario { get; set; }
    }
}
