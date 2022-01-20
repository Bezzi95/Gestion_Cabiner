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

    [Route("api/sexes")]
    [ApiController]
    public class SexesController : ControllerBase
    {

        private readonly ISexeRepository sexeRepository;
        public SexesController(ISexeRepository sexeRepository)
        {
            this.sexeRepository = sexeRepository;
        }

        // GET: api/<SexesController>
        [HttpGet]
        public async Task<ActionResult> GetSexes()
        {
            try
            {
                return Ok(await sexeRepository.GetSexes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");

            }
        }

        // GET api/<SexesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Sexe>> GetSexe(int id)
        {
            try
            {
                var result = await sexeRepository.GetSexe(id);
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
