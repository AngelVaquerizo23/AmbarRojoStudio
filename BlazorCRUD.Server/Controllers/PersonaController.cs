using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BlazorCRUD.Server.Models;
using BlazorCRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly EstadiaSqlContext _dbContext;

        public PersonaController(EstadiaSqlContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<PersonaShared>>();
            var listaPersona = new List<PersonaShared>();

            try
            {
                foreach (var item in await _dbContext.Personas.Include(d => d.IdRolesNavigation).ToListAsync())
                {
                    listaPersona.Add(new PersonaShared
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Direccion = item.Direccion,
                        Telefono = item.Telefono,
                        WhatsApp = item.WhatsApp,
                        Correo = item.Correo,
                        FechaRegistro = item.FechaRegistro,
                        IdRoles = new RolesShared 
                        { 
                           IdRoles = item.IdRolesNavigation.IdRoles,
                           Rol = item.IdRolesNavigation.Rol
                        }
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaPersona;

            }
            catch (Exception ex)
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
            var responseApi = new ResponseAPI<PersonaShared>();
            var Persona = new PersonaShared();

            try
            {
                var dbPersona = await _dbContext.Personas.FirstOrDefaultAsync(x => x.Id == id);

                if(dbPersona != null)
                {
                    Persona.Id = dbPersona.Id;
                    Persona.Nombre = dbPersona.Nombre;
                    Persona.Apellido = dbPersona.Apellido;
                    Persona.Direccion = dbPersona.Direccion;
                    Persona.Telefono = dbPersona.Telefono;
                    Persona.WhatsApp = dbPersona.WhatsApp;
                    Persona.Correo = dbPersona.Correo;
                    Persona.FechaRegistro = dbPersona.FechaRegistro;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = Persona;
                }

                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Usuario No Encontrado";
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
        public async Task<IActionResult> Guardar(PersonaShared persona)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbPersona = new Persona
                {
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    IdRoles = persona.IdRoles,
                    Direccion = persona.Direccion,
                    Telefono = persona.Telefono,
                    WhatsApp = persona.WhatsApp,
                    Correo = persona.Correo,
                    FechaRegistro = persona.FechaRegistro
                };

                _dbContext.Personas.Add(dbPersona);
                await _dbContext.SaveChangesAsync();

                if(dbPersona.Id != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbPersona.Id;
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
        public async Task<IActionResult> Editar(PersonaShared persona, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbPersona = await _dbContext.Personas.FirstOrDefaultAsync(e => e.Id == id);

                if (dbPersona != null)
                {
                    dbPersona.Nombre = persona.Nombre;
                    dbPersona.Apellido = persona.Apellido;
                    dbPersona.Direccion = persona.Direccion;
                    dbPersona.Telefono = persona.Telefono;
                    dbPersona.WhatsApp = persona.WhatsApp;
                    dbPersona.Correo = persona.Correo;
                    dbPersona.FechaRegistro = persona.FechaRegistro;

                    _dbContext.Personas.Update(dbPersona);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbPersona.Id;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Usuario no Encontrado";
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
        [Route("Elimnar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbPersona = await _dbContext.Personas.FirstOrDefaultAsync(e => e.Id == id);

                if (dbPersona != null)
                {
                    _dbContext.Personas.Remove(dbPersona);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Usuario no Encontrado";
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