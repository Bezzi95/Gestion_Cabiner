using CabinetWebAPI.Model;
using CabinetWebAPI.Model.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CabinetWebAPI.Controllers
{
    [Route("api/villes")]
    [ApiController]
    public class VillesController : ControllerBase
    {

        public readonly IVilleRepository villeRepository;

        public VillesController(IVilleRepository villeRepository)
        {
            this.villeRepository = villeRepository;
        }



        // GET: api/<VillesController>
        [HttpGet]
        public async Task<ActionResult> GetVilles()
        {
            try
            {
                return Ok(await villeRepository.GetVilles());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");

            }
        }

        // GET api/<VillesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ville>> GetVille(int id)
        {
            try
            {
                var result = await villeRepository.GetVille(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");

            }
        }


    }
}
