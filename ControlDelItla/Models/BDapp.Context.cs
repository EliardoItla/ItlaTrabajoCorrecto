﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlDelItla.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ControlItlaEntities2 : DbContext
    {
        public ControlItlaEntities2()
            : base("name=ControlItlaEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Asignatura> Asignaturas { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<EstudianteAsignatura> EstudianteAsignaturas { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
        public virtual DbSet<ProfesorAsignatura> ProfesorAsignaturas { get; set; }

        public System.Data.Entity.DbSet<ControlDelItla.Models.TableView.ListaAsignarProf> ListaAsignarProfs { get; set; }

        public System.Data.Entity.DbSet<ControlDelItla.Models.TableView.ListaSeleccionarMateria> ListaSeleccionarMaterias { get; set; }
    }
}
