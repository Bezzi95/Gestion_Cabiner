using Gestion_Cabinet_Front.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Pages
{
    public class DeletePatientBase : ComponentBase
    {
        [Inject]
        public IPatientService PatientService { get; set; }

        public Patient Patient { get; set; } =  new Patient();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Patient = await PatientService.GetPatient(int.Parse(Id));
        }

        protected async Task Delete_Click()
        {
            await PatientService.DeletePatient(Patient.id);
            NavigationManager.NavigateTo("/");
        }

    }
}
