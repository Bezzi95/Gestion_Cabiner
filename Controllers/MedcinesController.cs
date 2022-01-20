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
    [Route("api/Medcines")]
    [ApiController]
    public class MedcinesController : ControllerBase
    {
        private readonly IMedcineRepository medcineRepository;

        public MedcinesController(IMedcineRepository medcineRepository)
        {
            this.medcineRepository = medcineRepository;
        }


        // GET: api/<MedcinesController>
        [HttpGet]
        public async Task<ActionResult> GetMedcines()
        {
            try
            {
                return Ok(await medcineRepository.GetMedcines());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        // GET api/<MedcinesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Medcine>> GetMedcine(int id)
        {
            try
            {
                var result = await medcineRepository.GetMedcine(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        // POST api/<MedcinesController>
        [HttpPost]
        public async Task<ActionResult<Medcine>> CreateMedcine(Medcine medcine)
        {
            try
            {
                if (medcine == null)
                {
                    return BadRequest();
                }
                else
                {
                    var med = await medcineRepository.GetMedcineByEmail(medcine.Email);
                    if (med != null)
                    {
                        ModelState.AddModelError("email", "Medcine email already in use");
                        return BadRequest(ModelState);
                    }
                    else
                    {
                        var createdMedcine = await medcineRepository.AddMedcine(medcine);
                        return CreatedAtAction(nameof(GetMedcine), new{ id = createdMedcine.id },
                        createdMedcine);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }

        }

        // PUT api/<MedcinesController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Medcine>> UpdateMedcine(int id, Medcine medcine)
        {
            try
            {
                if (id != medcine.id)
                    return BadRequest("Medcine ID mismatch");

                var medcineToUpdate = await medcineRepository.GetMedcine(id);

                if (medcineToUpdate == null)
                    return NotFound($"Medcine with ID ={id} not found");
                return await medcineRepository.UpdateMedcine(medcine);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "ERROR update data");
            }
        }

        // DELETE api/<MedcinesController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Medcine>> DeleteMedcine(int id)
        {
            try
            {
                var medcineToDelete = await medcineRepository.GetMedcine(id);

                if (medcineToDelete == null)
                    return NotFound($"Medcine with ID ={id} not found");

                return await medcineRepository.DeleteMedcine(id);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "ERROR delete data");
            }
        }
    }
}
