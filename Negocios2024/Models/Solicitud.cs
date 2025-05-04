using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Negocios2024.Models
{
    public class Solicitud
    {
        [DisplayName("N° Solicitud")]
        public string nsol { get; set; }
        [DisplayName("Fecha Solicitud")]
        public DateTime fsol { get; set; }
        [DisplayName("Cliente")]
        public string cliente { get; set; }
        [DisplayName("Direccion")]
        public string dircliente { get; set; }
        [DisplayName("ID Empleado")]
        public int idempleado { get; set; }
        [DisplayName("Monto")]
        public decimal monto { get; set; }

        public Solicitud() { }

        public Solicitud(string nsol, DateTime fsol, string cliente, string dircliente, int idempleado, decimal monto)
        {
            this.nsol = nsol;
            this.fsol = fsol;
            this.cliente = cliente;
            this.dircliente = dircliente;
            this.idempleado = idempleado;
            this.monto = monto;
        }
    }
}