
using Gestion_Cabinet_Front.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Pages
{
    public class PatientListBase : ComponentBase
    {
        [Inject]
        public IPatientService PatientService { get; set; }
        public IEnumerable<Patient> Patients { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Patients = new List<Patient>();
            Patients = (await PatientService.GetPatients()).ToList();
        }



    }
}
