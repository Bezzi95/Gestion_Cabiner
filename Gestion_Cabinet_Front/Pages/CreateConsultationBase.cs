using Gestion_Cabinet_Front.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Pages
{
    public class CreateConsultationBase: ComponentBase
    {
        [Inject]
        public IConsultationService ConsultationService { get; set; }
        public Consultation consultation { get; set; } = new Consultation();
        [Inject]
        public IPatientService PatientService { get; set; }
        public List<Patient> Patients { get; set; } = new List<Patient>();

        public string PatientId { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            consultation = new Consultation
            {
                
                Date_Consult = DateTime.Now,
             
               

            };
            Patients = (await PatientService.GetPatients()).ToList();
            PatientId = consultation.Patientid.ToString();
        }
        protected async  Task  HandleValidSubmit()
        {
            consultation.Patientid = int.Parse(PatientId);
            consultation.Medecinid = 2;

            var result = await ConsultationService.CreateConsultation(consultation);
            if (result!=null)
            { NavigationManager.NavigateTo("/"); }
        }

    }
}


       