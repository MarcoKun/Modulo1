using System;
using System.Collections.Generic;

namespace ModuloCRUD.Models;

public partial class EspacioTrabajo
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

    public virtual EstatusLicencia EstatusLicenciaIdEstatusLicenciaNavigation { get; set; } = null!;

    public virtual TipoLicencia TipoLicenciaIdTipoLicenciaNavigation { get; set; } = null!;
}
