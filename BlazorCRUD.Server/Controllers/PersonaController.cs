using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorCRUD.Server.Models;
using BlazorCRUD.Shared;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var responseAPI = new ResponseAPI<List<PersonasShared>>();

            var listaPersonas = new List<PersonasShared>();

            try
            {
                foreach (var item in await _dbContext.Personas.Include(d => d.IdRolesNavigation).ToListAsync())
                {
                    listaPersonas.Add(new PersonasShared
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Direccion = item.Direccion,
                        Telefono = item.Telefono,
                        WhatsApp = item.WhatsApp,
                        Correo = item.Correo,
                        IdRoles = item.IdRoles,
                        FechaRegitro = item.FechaRegitro,
                        Roles = new RolesShared
                        {
                            IdRoles = item.IdRolesNavigation.IdRoles,
                            Rol = item.IdRolesNavigation.Rol
                        }
                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listaPersonas;
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseAPI = new ResponseAPI<PersonasShared>();

            var Personas = new PersonasShared();

            try
            {
                var dbPersona = await _dbContext.Personas.FirstOrDefaultAsync(x => x.Id == id);
                if (dbPersona != null)
                {
                    Personas.Id = dbPersona.Id;
                    Personas.Nombre = dbPersona.Nombre;
                    Personas.Apellido = dbPersona.Apellido;
                    Personas.Direccion = dbPersona.Direccion;
                    Personas.Telefono = dbPersona.Telefono;
                    Personas.WhatsApp = dbPersona.WhatsApp;
                    Personas.Correo = dbPersona.Correo;
                    Personas.IdRoles = dbPersona.IdRoles;
                    Personas.FechaRegitro = dbPersona.FechaRegitro;

                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = Personas;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "No se encontro el usuario";
                }
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(PersonasShared personas)
        {
            var responseAPI = new ResponseAPI<int>();

            try
            {
                var dbPersona = new Persona
                {
                    Nombre = personas.Nombre,
                    Apellido = personas.Apellido,
                    Direccion = personas.Direccion,
                    Telefono = personas.Telefono,
                    WhatsApp = personas.WhatsApp,
                    Correo = personas.Correo,
                    IdRoles = personas.IdRoles,
                    FechaRegitro = personas.FechaRegitro
                };

                _dbContext.Personas.Add(dbPersona);
                await _dbContext.SaveChangesAsync();

                if(dbPersona.Id != 0)
                {
                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = dbPersona.Id;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "No Guardado";
                }

            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(PersonasShared personas, int id)
        {
            var responseAPI = new ResponseAPI<int>();

            try
            {
                var dbPersona = await _dbContext.Personas.FirstOrDefaultAsync(e => e.Id == id);

                if (dbPersona != null)
                {
                    dbPersona.Nombre = personas.Nombre;
                    dbPersona.Apellido = personas.Apellido;
                    dbPersona.Direccion = personas.Direccion;
                    dbPersona.Telefono = personas.Telefono;
                    dbPersona.WhatsApp = personas.WhatsApp;
                    dbPersona.Correo = personas.Correo;
                    dbPersona.IdRoles = personas.IdRoles;
                    dbPersona.FechaRegitro = personas.FechaRegitro;

                    _dbContext.Personas.Update(dbPersona);
                    await _dbContext.SaveChangesAsync();

                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = dbPersona.Id;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "Usuario no encontrado";
                }

            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseAPI = new ResponseAPI<int>();

            try
            {
                var dbPersona = await _dbContext.Personas.FirstOrDefaultAsync(e => e.Id == id);

                if (dbPersona != null)
                {
                    _dbContext.Personas.Remove(dbPersona);
                    await _dbContext.SaveChangesAsync();

                    responseAPI.EsCorrecto = true;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "Usuario no encontrado";
                }

            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }
    }
}