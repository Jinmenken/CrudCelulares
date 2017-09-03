using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellCrud.Models
{
    public class Celular
    {
        public int CelularID { get; set; }
        public int MarcaID { get; set; }
        public int OSID { get; set; }
        public string Operadora { get; set; }
        public double Costo { get; set; }
        public string NombreCliente { get; set; }
    }
}