using Gestion_Cabinet_Front.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Pages
{
    public class ConsultationPatientBase : ComponentBase
    {
       
            [Inject]
            public IConsultationService ConsultationService { get; set; }
           // public IEnumerable<Consultation> Consultations { get; set; }
        public List<Consultation> Consultations { get; set; } = new List<Consultation>();


        [Inject]
            public IPatientService PatientService { get; set; }
            public List<Patient> Patients { get; set; } = new List<Patient>();

            public string PatientId { get; set; }
            [Parameter]
            public string Id { get; set; }
            [Inject]
            public NavigationManager NavigationManager { get; set; }

      
        public Patient patient { get; set; } = new Patient();
        public Medcine Medecin { get; set; } = new Medcine();



        protected async override Task OnInitializedAsync()
            {

           
                Patients = (await PatientService.GetPatients()).ToList();
              
            Consultations = (await ConsultationService.GetConsultationsByPatient(int.Parse(Id))).ToList();
        }

           





        }
    }
