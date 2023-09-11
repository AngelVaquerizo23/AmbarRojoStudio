using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorCRUD.Server.Models;
using BlazorCRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly EstadiaSqlContext _dbContext;

        public RolesController(EstadiaSqlContext dbContext)
        {
            _dbContext = dbContext;  
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista() 
        {
            var responseApi = new ResponseAPI<List<RolesShared>>();
            var listaRoles = new List<RolesShared>();

            try
            {
                foreach(var item in await _dbContext.Roles.ToListAsync())
                {
                    listaRoles.Add(new RolesShared
                    {
                        IdRoles = item.IdRoles,
                        Rol = item.Rol,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaRoles;

            }catch(Exception ex) 
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}