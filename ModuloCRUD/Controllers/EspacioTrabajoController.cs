using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ModuloCRUD.Models;
using Modulo1.Shared;
using Microsoft.EntityFrameworkCore;

namespace ModuloCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspacioTrabajoController : ControllerBase
    {
        private readonly PropuestaDb1Context _dbContext;

        public EspacioTrabajoController(PropuestaDb1Context dbContext) {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<EspacioTrabajoDTO>>();
            var listaEspacioTrabajoDTO = new List<EspacioTrabajoDTO>();

            try
            {
                foreach(var item in await _dbContext.EspacioTrabajo.ToListAsync())
                {
                    listaEspacioTrabajoDTO.Add(new EspacioTrabajoDTO()
                    {
                        IdEspacioTrabajo = item.IdEspacioTrabajo,
                        NombreEspacioTrabajo = item.NombreEspacioTrabajo,
                        Usuario = item.Usuario,
                        NombreAdministradorEspacio = item.NombreAdministradorEspacio,
                        CorreoAdministrador = item.CorreoAdministrador,
                        TelefonoContacto = item.TelefonoContacto,
                        FechaInicioLicencia = item.FechaInicioLicencia,
                        FechaCaducidadLicencia = item.FechaCaducidadLicencia,
                        NombreInstitucion = item.NombreInstitucion,
                        FechaCreacionEspacioTrabajo = item.FechaCreacionEspacioTrabajo,
                        EstatusLicenciaIdEstatusLicencia = item.EstatusLicenciaIdEstatusLicencia,
                        TipoLicenciaIdTipoLicencia = item.TipoLicenciaIdTipoLicencia,

                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaEspacioTrabajoDTO;
            }catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Buscar/{id}")]

        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<EspacioTrabajoDTO>();
            var EspacioTrabajoDTO = new EspacioTrabajoDTO();

            try
            {
                var dbEspacioTrabajo = await _dbContext.EspacioTrabajo.FirstOrDefaultAsync(x => x.IdEspacioTrabajo == id);
                if(dbEspacioTrabajo == null)
                {
                    EspacioTrabajoDTO.IdEspacioTrabajo = EspacioTrabajoDTO.IdEspacioTrabajo;
                    EspacioTrabajoDTO.NombreEspacioTrabajo = EspacioTrabajoDTO.NombreEspacioTrabajo;
                    EspacioTrabajoDTO.NombreAdministradorEspacio = EspacioTrabajoDTO.NombreAdministradorEspacio;
                    EspacioTrabajoDTO.CorreoAdministrador = EspacioTrabajoDTO.CorreoAdministrador;
                    EspacioTrabajoDTO.TelefonoContacto = EspacioTrabajoDTO.TelefonoContacto;
                    EspacioTrabajoDTO.FechaInicioLicencia = EspacioTrabajoDTO.FechaInicioLicencia;
                    EspacioTrabajoDTO.FechaCaducidadLicencia = EspacioTrabajoDTO.FechaCaducidadLicencia;
                    EspacioTrabajoDTO.NombreInstitucion = EspacioTrabajoDTO.NombreInstitucion;
                    EspacioTrabajoDTO.FechaCreacionEspacioTrabajo = EspacioTrabajoDTO.FechaCreacionEspacioTrabajo;
                    EspacioTrabajoDTO.EstatusLicenciaIdEstatusLicencia = EspacioTrabajoDTO.EstatusLicenciaIdEstatusLicencia;
                    EspacioTrabajoDTO.TipoLicenciaIdTipoLicencia = EspacioTrabajoDTO.TipoLicenciaIdTipoLicencia;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = EspacioTrabajoDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }

                
               
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpPost]
        [Route("Guardar")]

        public async Task<IActionResult> Guardar(EspacioTrabajoDTO Espacio)
        {
            var responseApi = new ResponseAPI<int>();


            try
            {
                var dbEspacioTrabajo = new EspacioTrabajo
                {
                    NombreEspacioTrabajo = Espacio.NombreEspacioTrabajo,
                    IdEspacioTrabajo = Espacio.IdEspacioTrabajo,
                    Usuario = Espacio.Usuario,
                    NombreAdministradorEspacio = Espacio.NombreAdministradorEspacio,
                    CorreoAdministrador = Espacio.CorreoAdministrador,
                    TelefonoContacto = Espacio.TelefonoContacto,
                    FechaInicioLicencia = Espacio.FechaInicioLicencia,
                    FechaCaducidadLicencia = Espacio.FechaCaducidadLicencia,
                    NombreInstitucion = Espacio.NombreInstitucion,
                    FechaCreacionEspacioTrabajo = Espacio.FechaCreacionEspacioTrabajo,
                    EstatusLicenciaIdEstatusLicencia = Espacio.EstatusLicenciaIdEstatusLicencia,
                    TipoLicenciaIdTipoLicencia = Espacio.TipoLicenciaIdTipoLicencia,

                };

                _dbContext.EspacioTrabajo.Add(dbEspacioTrabajo);
                await _dbContext.SaveChangesAsync();
                if (dbEspacioTrabajo.IdEspacioTrabajo != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbEspacioTrabajo.IdEspacioTrabajo;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No Guardado";
                }

                


            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }


        [HttpPut]
        [Route("Editar/{id}")]

        public async Task<IActionResult> Editar(EspacioTrabajoDTO Espacio,int id)
        {
            var responseApi = new ResponseAPI<int>();


            try
            {

                var dbEspacioTrabajo = await _dbContext.EspacioTrabajo.FirstOrDefaultAsync(e => e.IdEspacioTrabajo == id);

                
                if (dbEspacioTrabajo != null)
                {
                    dbEspacioTrabajo.NombreEspacioTrabajo = Espacio.NombreEspacioTrabajo;
                    dbEspacioTrabajo.IdEspacioTrabajo = Espacio.IdEspacioTrabajo;
                    dbEspacioTrabajo.Usuario = Espacio.Usuario;
                    dbEspacioTrabajo.NombreAdministradorEspacio = Espacio.NombreAdministradorEspacio;
                    dbEspacioTrabajo.CorreoAdministrador = Espacio.CorreoAdministrador;
                    dbEspacioTrabajo.TelefonoContacto = Espacio.TelefonoContacto;
                    dbEspacioTrabajo.FechaInicioLicencia = Espacio.FechaInicioLicencia;
                    dbEspacioTrabajo.FechaCaducidadLicencia = Espacio.FechaCaducidadLicencia;
                    dbEspacioTrabajo.NombreInstitucion = Espacio.NombreInstitucion;
                    dbEspacioTrabajo.FechaCreacionEspacioTrabajo = Espacio.FechaCreacionEspacioTrabajo;
                    dbEspacioTrabajo.EstatusLicenciaIdEstatusLicencia = Espacio.EstatusLicenciaIdEstatusLicencia;
                    dbEspacioTrabajo.TipoLicenciaIdTipoLicencia = Espacio.TipoLicenciaIdTipoLicencia;


                    _dbContext.EspacioTrabajo.Add(dbEspacioTrabajo);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbEspacioTrabajo.IdEspacioTrabajo;


                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Espacio De Trabajo No Encontrado";
                }




            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("Elminar/{id}")]

        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();


            try
            {

                var dbEspacioTrabajo = await _dbContext.EspacioTrabajo.FirstOrDefaultAsync(e => e.IdEspacioTrabajo == id);


                if (dbEspacioTrabajo != null)
                {
          
                    _dbContext.EspacioTrabajo.Remove(dbEspacioTrabajo);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                 


                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Espacio De Trabajo No Encontrado";
                }




            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }
    }
}
