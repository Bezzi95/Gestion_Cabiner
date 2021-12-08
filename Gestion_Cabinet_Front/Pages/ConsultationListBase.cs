using Gestion_Cabinet_Front.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Pages
{
    public class ConsultationListBase : ComponentBase
    {
        [Inject]
        public IConsultationService consultationService { get; set; }
        public IEnumerable<Consultation> Consultations { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Consultations = new List<Consultation>();
            Consultations = (await consultationService.GetConsultations()).ToList();
        }



    }
}
