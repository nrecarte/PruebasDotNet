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
    
    public partial class rolperfil
    {
        public int rolperfil_id { get; set; }
        public Nullable<int> rolperfil_perfil_id { get; set; }
        public Nullable<int> rolperfil_rol_id { get; set; }
    
        public virtual rol rol { get; set; }
        public virtual perfil perfil { get; set; }
    }
}
