using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace Modulo1.Shared
{
    public class EstatusLicenciaDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
       
        public int IdEstatusLicencia { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Estatus { get; set; } = null!;

        public EspacioTrabajoDTO? EspacioTrabajo { get; set; }

        public static void Add(EstatusLicenciaDTO estatusLicenciaDTO)
        {
            throw new NotImplementedException();
        }
    }
}
