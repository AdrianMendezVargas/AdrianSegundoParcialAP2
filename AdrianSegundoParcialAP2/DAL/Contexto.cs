using AdrianSegundoParcialAP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdrianSegundoParcialAP2.DAL {
    public class Contexto : DbContext{

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Cobro> Cobros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source= Data/Ventas.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Cliente>().HasData(new Cliente() {ClienteId = 1, Nombres = "FERRETERIA GAMA" });

            modelBuilder.Entity<Venta>().HasData(new Venta() { VentaId = 1, Fecha = new DateTime(2020 , 09 , 01) , ClienteId = 1 , Monto = 1000 , Balance = 1000 });

            modelBuilder.Entity<Venta>().HasData(new Venta() { VentaId = 2 , Fecha = new DateTime(2020 , 10 , 01) , ClienteId = 1 , Monto = 900 , Balance = 800 });



            modelBuilder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 2, Nombres = "AVALON DISCO" });

            modelBuilder.Entity<Venta>().HasData(new Venta() { VentaId = 3 , Fecha = new DateTime(2020 , 09 , 01) , ClienteId = 2 , Monto = 2000 , Balance = 2000 });

            modelBuilder.Entity<Venta>().HasData(new Venta() { VentaId = 4 , Fecha = new DateTime(2020 , 10 , 01) , ClienteId = 2 , Monto = 1900 , Balance = 1800 });



            modelBuilder.Entity<Cliente>().HasData(new Cliente() { ClienteId = 3, Nombres = "PRESTAMOS CEFIPROD" });

            modelBuilder.Entity<Venta>().HasData(new Venta() { VentaId = 5 , Fecha = new DateTime(2020 , 09 , 01) , ClienteId = 3 , Monto = 3000 , Balance = 3000 });

            modelBuilder.Entity<Venta>().HasData(new Venta() {VentaId = 6, Fecha = new DateTime(2020 , 10 , 01) , ClienteId = 3 , Monto = 2900 , Balance = 1900 });

        }

    }
}
