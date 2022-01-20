using Gestion_Cabinet_Front.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Cabinet_Front.Pages
{
    public class CreateMedecinBase: ComponentBase 
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

       [Inject]
       public IVilleService VilleService { get; set; }
       public List<Ville> Villes { get; set; } = new List<Ville>();
       public string Villeid { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Medcine = new Medcine
            {
                photo = "images/Doctor.png"
            };
            Sexes = (await SexeService.GetSexes()).ToList();
            Sexeid = Medcine.Sexeid.ToString();

            Specialites = (await SpecialiteService.GetSpecialites()).ToList();
            Specialiteid = Medcine.Specialiteid.ToString();

            Villes = (await VilleService.GetVilles()).ToList();
            Villeid = Medcine.Villeid.ToString();
        }

        protected async Task HandleValidSubmit()
        {
           Medcine.Sexeid = int.Parse(Sexeid);
           Medcine.Specialiteid = int.Parse(Specialiteid);
            Medcine.Villeid = int.Parse(Villeid);


            //Medcine.Sexe = await SexeService.GetSexe(int.Parse(Sexeid));

            //Medcine.Sexeid = 2;
            // Medcine.Specialiteid = 4;
           // Medcine.Villeid = 1;
            var result = await MedecinService.CreateMedecin(Medcine); 
            if(result != null)
            {
               NavigationManager.NavigateTo("/MedecinList");
                                             
            }
        }
    }
}
