using Gestion_Cabinet_Front.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Pages
{
    public class MedecinListBase : ComponentBase
    {
        [Inject]
        public IMedecinService MedecinService { get; set; }
        public IEnumerable<Medcine>Medcines { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Medcines = new List<Medcine>();
            Medcines = (await MedecinService.GetMedecins()).ToList();
        }
    }
}
