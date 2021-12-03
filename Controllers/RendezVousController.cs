using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
    [Route("api/[controller]")]
    [ApiController]
    public class RendezVousController : ControllerBase
    {
        private readonly IRendez_VousRepository rendezvousRepository;

        public RendezVousController(IRendez_VousRepository rendezvousRepository)
        {
            this.rendezvousRepository = rendezvousRepository;
        }

        // GET: api/<ConsultationController>
        [HttpGet]
        public async Task<ActionResult> GetRendez_vouss()
        {
            try
            {
                return Ok(await rendezvousRepository.GetRendez_vouss());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        // GET api/<ConsultationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rendez_vous>> GetRendez_vous(int id)
        {
            try
            {
                var result = await rendezvousRepository.GetRendez_vous(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }
        // POST api/<ConsultationController>
        [HttpPost]
        public async Task<ActionResult<Rendez_vous>> CreateConsultation(Rendez_vous rendezvous)
        {
            try
            {
                if (rendezvous == null)
                {
                    return BadRequest();
                }
                else
                {

                    var createdRendez_vous = await rendezvousRepository.AddRendez_vous(rendezvous);
                    return CreatedAtAction(nameof(GetRendez_vous),
                        new { id = createdRendez_vous.Id },
                    createdRendez_vous);


                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }

        }

        // PUT api/<ConsultationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Rendez_vous>> UpdateConsultation(int id, Rendez_vous rendezvous)
        {
            try
            {
                if (id != rendezvous.Id)
                    return BadRequest("rendezvous ID mismatch");

                var consultationToUpdate = await rendezvousRepository.GetRendez_vous(id);

                if (consultationToUpdate == null)
                    return NotFound($"rendezvous with ID ={id} not found");
                return await rendezvousRepository.UpdateRendez_vous(rendezvous);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "ERROR update data");
            }
        }

        // DELETE api/<ConsultationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rendez_vous>> DeleteConsultation(int id)
        {
            try
            {
                var rendezvousToDelete = await rendezvousRepository.GetRendez_vous(id);

                if (rendezvousToDelete == null)
                    return NotFound($"rendezvous with ID ={id} not found");

                return await rendezvousRepository.DeleteRendez_vous(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "ERROR delete data");
            }
        }

   
        [HttpGet("getbyDate/{Date1}&{Date2}")]
        public async Task<ActionResult> GetRendez_vousByDate(DateTime Date1, DateTime Date2)
        {
            try
            {
                return Ok(await rendezvousRepository.GetRendez_vousByDate(Date1, Date2));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }
        // GET api/<ConsultationController>/5
        [HttpGet("getbyPatient/patientId")]
        public async Task<ActionResult> GetRendez_vousByPatient([FromQuery] int patientId)
        {
            try
            {
                return Ok(await rendezvousRepository.GetRendez_vousByPatient(patientId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        // GET api/<ConsultationController>/5

        [HttpGet("getbyMedecin/medecinId")]
        public async Task<ActionResult> GetRendez_vousByMedecin([FromQuery] int medecinId)
        {
            try
            {
                return Ok(await rendezvousRepository.GetRendez_vousByMedecin(medecinId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }
  
        [HttpGet("search/")]
        public async Task<ActionResult> Search([FromQuery] string patientname, [FromQuery] string medecinname, [FromQuery] string status)
        {
            try
            {
                return Ok(await rendezvousRepository.Search(patientname, medecinname,status));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

    }
}
