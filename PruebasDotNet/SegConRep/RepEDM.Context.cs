﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class segconrepEntities : DbContext
    {
        public segconrepEntities()
            : base("name=segconrepEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<aplicacion> aplicacion { get; set; }
        public DbSet<estadousuario> estadousuario { get; set; }
        public DbSet<grupo> grupo { get; set; }
        public DbSet<perfilaplicacion> perfilaplicacion { get; set; }
        public DbSet<perfilprivilegio> perfilprivilegio { get; set; }
        public DbSet<privilegio> privilegio { get; set; }
        public DbSet<rol> rol { get; set; }
        public DbSet<rolperfil> rolperfil { get; set; }
        public DbSet<usuario> usuario { get; set; }
        public DbSet<perfil> perfil { get; set; }
        public DbSet<departamento> departamento { get; set; }
        public DbSet<emisionevento> emisionevento { get; set; }
        public DbSet<emisionlimite> emisionlimite { get; set; }
        public DbSet<emisionproceso> emisionproceso { get; set; }
        public DbSet<eventoestado> eventoestado { get; set; }
        public DbSet<poliza> poliza { get; set; }
        public DbSet<polizaestado> polizaestado { get; set; }
        public DbSet<ramo> ramo { get; set; }
    }
}
