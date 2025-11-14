using JuliePro.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models
{

    /// <summary>
    /// Le TrainerSearchViewModelFilter contient la partie du formulaire. 
    /// Le TrainerSearchViewModel contient le reste
    /// </summary>
    public class TrainerSearchViewModel : TrainerSearchViewModelFilter
    {

        public TrainerSearchViewModel()
        {

        }

        public TrainerSearchViewModel(TrainerSearchViewModelFilter filter)
        {
            this.SelectedDisciplineId = filter.SelectedDisciplineId;
            this.SelectedCertificationId = filter.SelectedCertificationId;
            this.SelectedPageSize = filter.SelectedPageSize ;
            this.SelectedPageIndex = filter.SelectedPageIndex;
            this.SelectedGender = filter.SelectedGender;
            this.SearchNameText = filter.SearchNameText;
            this.SelectedCertificationCenter = filter.SelectedCertificationCenter;
            this.VerifyProperties();
        }

        [Display(Name = "Items")]
        public PaginatedList<Trainer> Items { get; set; }
        
        [Display(Name = "Disciplines")]
        public SelectList Disciplines { get; set; }
        
        [Display(Name = "Certifications")]
        public SelectList Certifications { get; set; }
        
        [Display(Name = "CertificationCenters")]
        public SelectList CertificationCenters { get; set; }
        
        [Display(Name = "AvailablePageSizes")]
        public SelectList AvailablePageSizes { get; set; }
    }
}
