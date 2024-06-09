using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Modulo1.Shared
{
    internal class TipoLicenciaDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int IdTipoLicencia { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Tipo { get; set; } = null!;

        public EspacioTrabajoDTO? EspacioTrabajo { get; set; }
    }
}
