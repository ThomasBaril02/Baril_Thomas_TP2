using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models
{
    public class Certification
    {
        [Display(Name="Id")]
        public int Id { get; set; }

        [Required()]
        [StringLength(255, MinimumLength = 5)]
        [Display(Name="Title")]
        public string Title { get; set; }

        [StringLength(255)]
        [Display(Name="CertificationCenter")]
        public string CertificationCenter { get; set; }

        [Display(Name="TrainerCertifications")]
        public virtual ICollection<TrainerCertification> TrainerCertifications { get; set; }

        [Display(Name = "Title")]
        public string FullTitle { get { return $"{Title} ({CertificationCenter})"; } }

    }
}