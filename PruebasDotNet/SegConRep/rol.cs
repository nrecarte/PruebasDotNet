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
    
    public partial class rol
    {
        public rol()
        {
            this.rolperfil = new HashSet<rolperfil>();
        }
    
        public int rol_id { get; set; }
        public string rol_nombre { get; set; }
        public string rol_descripcion { get; set; }
    
        public virtual ICollection<rolperfil> rolperfil { get; set; }
    }
}
