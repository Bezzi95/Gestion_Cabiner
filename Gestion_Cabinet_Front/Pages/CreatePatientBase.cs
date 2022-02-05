using Gestion_Cabinet_Front.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Pages
{
    public class CreatePatientBase : ComponentBase
    {
        [Inject]
        public IPatientService PatientService { get; set; }

        public Patient Patient { get; set; } = new Patient();

        
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Patient = new Patient
            {
                Date_naiss = DateTime.Now,
                photo = "images/Patient.png"
              
            };
        }

        protected async Task HandleValidSubmit()
        {
            var result = await PatientService.CreatePatient(Patient);
            if( result != null)
            {
                NavigationManager.NavigateTo("/PatientList");
            }
        }


    }
}
