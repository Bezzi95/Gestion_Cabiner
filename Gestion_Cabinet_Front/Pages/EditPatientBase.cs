using Gestion_Cabinet_Front.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Pages
{
    public class EditPatientBase : ComponentBase
    {

        public Patient Patient { get; set; } = new Patient();
        [Inject]
        public IPatientService PatientService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Patient = await PatientService.GetPatient(int.Parse(Id));
        }

        protected async Task HandleValidSubmit()
        {
            var result = await PatientService.UpdatePatient(Patient);
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        protected async Task Delete_Click()
        {
            await PatientService.DeletePatient(Patient.id);
            NavigationManager.NavigateTo("/");
        }
    }
}
