using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo1.Shared
{
    public class EspacioTrabajoDTO
    {
        public int IdEspacioTrabajo { get; set; }

        public string NombreEspacioTrabajo { get; set; } = null!;

        public string Usuario { get; set; } = null!;

        public string NombreAdministradorEspacio { get; set; } = null!;

        public string CorreoAdministrador { get; set; } = null!;

        public string TelefonoContacto { get; set; } = null!;

        public DateTime FechaInicioLicencia { get; set; }

        public DateTime FechaCaducidadLicencia { get; set; }

        public string NombreInstitucion { get; set; } = null!;

        public DateTime? FechaCreacionEspacioTrabajo { get; set; }

        public int EstatusLicenciaIdEstatusLicencia { get; set; }

        public int TipoLicenciaIdTipoLicencia { get; set; }


    }
}
