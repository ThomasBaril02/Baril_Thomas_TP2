using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models
{
    public class TrainerSearchViewModelFilter
    {
        [Display(Name = "SearchNameText")]
        public string? SearchNameText { get; set; }
        
        [Display(Name = "SelectedDisciplineId")]
        public int? SelectedDisciplineId { get; set; }

        [Display(Name = "SelectedCertificationId")]
        public int? SelectedCertificationId { get; set; }

        [Display(Name = "SelectedCertificationCenter")]
        public string? SelectedCertificationCenter { get; set; }

        [Display(Name = "SelectedGenre")]
        public Genre? SelectedGender { get; set; }

        [Display(Name = "SelectedPageSize")]
        [Range(3, 30, ErrorMessage = "{0} should be between {1} and {2}")]
        public int SelectedPageSize { get; set; }

        [Display(Name = "SelectedPageIndex")]
        public int SelectedPageIndex { get; set; }

        public void VerifyProperties()
        {
            this.SelectedDisciplineId = this.SelectedDisciplineId == 0 ? null : this.SelectedDisciplineId;
            this.SelectedCertificationId = this.SelectedCertificationId == 0 ? null : this.SelectedCertificationId;
            this.SelectedPageSize = this.SelectedPageSize == 0 ? 9 : this.SelectedPageSize;
            this.SelectedPageIndex = this.SelectedPageIndex;
            this.SelectedGender = this.SelectedGender;
            this.SearchNameText = this.SearchNameText?.Trim() == String.Empty ? null : this.SearchNameText;
            this.SelectedCertificationCenter = this.SelectedCertificationCenter?.Trim() == String.Empty ? null : this.SelectedCertificationCenter;
        }
    }
}
