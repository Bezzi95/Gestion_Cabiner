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
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationRepository consultationRepository;

        public ConsultationController(IConsultationRepository consultationRepository)
        {
            this.consultationRepository = consultationRepository;
        }

        // GET: api/<ConsultationController>
        [HttpGet]
        public async Task<ActionResult> GetConsultations()
        {
            try
            {
                return Ok(await consultationRepository.GetConsultations());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        // GET api/<ConsultationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consultation>> GetConsultation(int id)
        {
            try
            {
                var result = await consultationRepository.GetConsultation(id);
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
        public async Task<ActionResult<Consultation>> CreateConsultation(Consultation consultation)
        {
            try
            {
                if (consultation == null)
                {
                    return BadRequest();
                }
                else
                {

                    var createdConsultation = await consultationRepository.AddConsultation(consultation);
                    return CreatedAtAction(nameof(GetConsultation),
                        new { id = createdConsultation.id },
                    createdConsultation);


                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }

        }

        // PUT api/<ConsultationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Consultation>> UpdateConsultation(int id, Consultation consultation)
        {
            try
            {
                if (id != consultation.id)
                    return BadRequest("consultation ID mismatch");

                var consultationToUpdate = await consultationRepository.GetConsultation(id);

                if (consultationToUpdate == null)
                    return NotFound($"Conultation with ID ={id} not found");
                return await consultationRepository.UpdateConsultation(consultation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "ERROR update data");
            }
        }

        // DELETE api/<ConsultationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Consultation>> DeleteConsultation(int id)
        {
            try
            {
                var medcineToDelete = await consultationRepository.GetConsultation(id);

                if (medcineToDelete == null)
                    return NotFound($"Consultation with ID ={id} not found");

                return await consultationRepository.DeleteConsultation(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "ERROR delete data");
            }
        }

        // GET api/<ConsultationController>/5
        // [HttpGet("search/{patientname}&{medecinname}")]
        [HttpGet("search/")]
        public async Task<ActionResult> Search([FromQuery] string patientname, [FromQuery] string medecinname)
        {
            try
            {
                return Ok(await consultationRepository.Search(patientname, medecinname));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        
        [HttpGet("getbyDate/{Date1}&{Date2}")]
        public async Task<ActionResult> GetConsultationsByDate(DateTime Date1, DateTime Date2)
        {
            try
            {
                return Ok(await consultationRepository.GetConsultationsByDate(Date1, Date2));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }
        // GET api/<ConsultationController>/5
        [HttpGet("getbyPatient/patientId")]
        public async Task<ActionResult> GetConsultationsByPatient( [FromQuery] int patientId)
        {
            try
            {
                return Ok(await consultationRepository.GetConsultationsByPatient(patientId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        // GET api/<ConsultationController>/5
      
        [HttpGet("getbyMedecin/medecinId")]
        public async Task<ActionResult> GetConsultationsByMedecin([FromQuery] int medecinId)
        {
            try
            {
                return Ok(await consultationRepository.GetConsultationsByMedecin(medecinId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }


    }
}
