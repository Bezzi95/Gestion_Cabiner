using Gestion_Cabinet_Front.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Pages
{
    public class DeleteMedecinBase : ComponentBase
    {
        [Inject]
        public IMedecinService MedecinService { get; set; }
        public Medcine Medcine { get; set; } = new Medcine();

        [Inject]
        public ISexeService SexeService { get; set; }
        public List<Sexe> Sexes { get; set; } = new List<Sexe>();
        public string Sexeid { get; set; }


        [Inject]
        public ISpecialiteService SpecialiteService { get; set; }
        public List<Specialite> Specialites { get; set; } = new List<Specialite>();
        public string Specialiteid { get; set; }


        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Medcine = await MedecinService.GetMedecin(int.Parse(Id));

            Sexes = (await SexeService.GetSexes()).ToList();
            Sexeid = Medcine.Sexeid.ToString();

            Specialites = (await SpecialiteService.GetSpecialites()).ToList();
            Specialiteid = Medcine.Specialiteid.ToString();
        }

        protected async Task Delete_Click()
        {
            await MedecinService.DeleteMedecin(Medcine.id);
            NavigationManager.NavigateTo("/MedecinList");
        }

    }
}
