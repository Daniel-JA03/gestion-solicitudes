using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Negocios2024.Models
{
    public class Empleado
    {
        [DisplayName("ID Empleado")]
        public int idempleado { get; set; }
        [DisplayName("Apellido")]
        public string apeempleado { get; set; }

        public Empleado() { }

        public Empleado(int idempleado, string apeempleado)
        {
            this.idempleado = idempleado;
            this.apeempleado = apeempleado;
        }
    }
}