using System;
using System.Collections.Generic;

namespace ModuloCRUD.Models;

public partial class EstatusLicencia
{
    public int IdEstatusLicencia { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual ICollection<EspacioTrabajo> EspacioTrabajos { get; } = new List<EspacioTrabajo>();
}
