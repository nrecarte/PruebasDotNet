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
    
    public partial class perfil
    {
        public perfil()
        {
            this.usuario = new HashSet<usuario>();
            this.perfilaplicacion = new HashSet<perfilaplicacion>();
            this.rolperfil = new HashSet<rolperfil>();
            this.perfilprivilegio = new HashSet<perfilprivilegio>();
        }
    
        public int perfil_id { get; set; }
        public string perfil_nombre { get; set; }
        public string perfil_descripcion { get; set; }
    
        public virtual ICollection<usuario> usuario { get; set; }
        public virtual ICollection<perfilaplicacion> perfilaplicacion { get; set; }
        public virtual ICollection<rolperfil> rolperfil { get; set; }
        public virtual ICollection<perfilprivilegio> perfilprivilegio { get; set; }
    }
}
