﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace torneos.Models
{
    public class torneosContext:DbContext
    {
        //Constructor por defecto
        public torneosContext():base("DefaultConnection") 
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        //Atributos
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<TorneoEquipo> TorneoEquipos { get; set; }
        public DbSet<Deportista> Deportistas { get; set; }
       
    }
}