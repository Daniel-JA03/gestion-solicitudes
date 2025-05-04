using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios2024.Models
{
    internal interface ISolicitudService
    {
        List<Solicitud> ListarSolicitudes();
        List<Empleado> ListarEmpleados();
        List<Solicitud> ConsultarPorEmpleado(int idempleado);
        bool InsertarSolicitud(Solicitud sol);
    }
}
