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
    
    public partial class perfilprivilegio
    {
        public int perfilprivilegio_id { get; set; }
        public int perfilprivilegio_perfil_id { get; set; }
        public int perfilprivilegio_privilegio_id { get; set; }
    
        public virtual privilegio privilegio { get; set; }
        public virtual perfil perfil { get; set; }
    }
}
