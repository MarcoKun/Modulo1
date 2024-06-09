using System;
using System.Collections.Generic;

namespace ModuloCRUD.Models;

public partial class TipoLicencia
{
    public int IdTipoLicencia { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<EspacioTrabajo> EspacioTrabajos { get; } = new List<EspacioTrabajo>();
}
