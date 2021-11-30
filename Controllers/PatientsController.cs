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
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }



        // GET: api/<PatientsController>
        [HttpGet]
        public async Task<ActionResult> GetPatients()
        {
            try
            {
                return Ok(await patientRepository.GetPatients());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        // GET api/<PatientsController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            try
            {
                var result = await patientRepository.GetPatient(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        // POST api/<PatientsController>
        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
        {
            try
            {
                if (patient == null)
                {
                    return BadRequest();
                }
                else
                {
                    var pat = await patientRepository.GetPatientByEmail(patient.Email);
                    if (pat != null)
                    {
                        ModelState.AddModelError("email", "Patient email already in use");
                        return BadRequest(ModelState);
                    }
                    else
                    {
                        var createdPatient = await patientRepository.AddPatient(patient);
                        return CreatedAtAction(nameof(GetPatient), new { id = createdPatient.id },
                        createdPatient);
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        // PUT api/<PatientsController>/5 
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Patient>> UpdatePatient(int id, Patient patient)
        {
            try
            {
                if (id != patient.id)
                    return BadRequest("Patient ID mismatch");

                var patientToUpdate = await patientRepository.GetPatient(id);

                if (patientToUpdate == null)
                    return NotFound($"Patient with ID ={id} not found");
                return await patientRepository.UpdatePatient(patient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "ERROR update data");
            }
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            try
            {
                var patientToDelete = await patientRepository.GetPatient(id);

                if (patientToDelete == null)
                    return NotFound($"Patient with ID ={id} not found");

                return await patientRepository.DeletePatient(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "ERROR delete data");
            }
        }
    }
}
