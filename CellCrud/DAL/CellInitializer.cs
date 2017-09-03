using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CellCrud.Models;

namespace CellCrud.DAL
{
    public class CellInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CellContext>
    {
        protected override void Seed(CellContext context)
        {
            var marcas = new List<Marca>
            {
            new Marca{Nombre="Motorola"},
            new Marca{Nombre="Apple"},
            new Marca{Nombre="LG"},
            new Marca{Nombre="Samsung"},
            };

            marcas.ForEach(s => context.Marcas.Add(s));
            context.SaveChanges();
            var opsys = new List<OS>
            {
            new OS{Nombre="Android"},
            new OS{Nombre="iOS"},
            new OS{Nombre="Windows Phone"},
            };
            opsys.ForEach(s => context.OpSys.Add(s));
            context.SaveChanges();
            var celulares = new List<Celular>
            {
            new Celular{MarcaID=1,OSID=1,Operadora="Claro",Costo=250.50,NombreCliente="Hannibal Lecter"},
            new Celular{MarcaID=2,OSID=2,Operadora="Movistar",Costo=300.00,NombreCliente="Richard Pickman"},
            new Celular{MarcaID=4,OSID=3,Operadora="Claro",Costo=250.50,NombreCliente="Hal Jordan"},
            };
            celulares.ForEach(s => context.Celulares.Add(s));
            context.SaveChanges();
        }
    }
}