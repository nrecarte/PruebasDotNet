//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueba
{
    using System;
    using System.Collections.Generic;
    
    public partial class country
    {
        public country()
        {
            this.city = new HashSet<city>();
        }
    
        public int country_id { get; set; }
        public string country1 { get; set; }
        public System.DateTime last_update { get; set; }
    
        public virtual ICollection<city> city { get; set; }
    }
}