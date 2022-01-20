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
    [Route("api/specialites")]
    [ApiController]
    public class SpecialitesController : ControllerBase
    {

        private readonly ISpecialiteRepository specialiteRepository;

        public SpecialitesController(ISpecialiteRepository specialiteRepository)
        {
            this.specialiteRepository = specialiteRepository;
        }


         // GET: api/<SpecialitesController>
        [HttpGet]
        public async Task<ActionResult> GetSpecialites()
        {
            try
            {
                return Ok(await specialiteRepository.GetSpecialites());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");

            }
        }

        // GET api/<SpecialitesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Specialite>> GetSpecialite(int id)
        {
            try
            {
                var result = await specialiteRepository.GetSpecialite(id);
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
