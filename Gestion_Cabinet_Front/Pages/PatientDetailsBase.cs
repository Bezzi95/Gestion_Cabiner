using Gestion_Cabinet_Front.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Pages
{
    public class PatientDetailsBase : ComponentBase
    {
        public Patient Patient { get; set; } = new Patient();
        [Inject]
        public IPatientService PatientService { get; set; }
        [Parameter]
        public string Id { get; set; }
        
        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Patient = await PatientService.GetPatient(int.Parse(Id));
        }


    }
}
