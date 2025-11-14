using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuliePro.Models
{
    public class TrainerCertification
    {
        [Display(Name="Id")]
        public int Id { get; set; }

        [ForeignKey("Trainer")]
        [Display(Name="Trainer_Id")]
        public int Trainer_Id { get; set; }

        [ForeignKey("Certification")]
        [Display(Name="Certification_Id")]
        public int Certification_Id { get; set; }

        [Display(Name="Trainer")]
        public virtual Trainer Trainer { get; set; }

        [Display(Name="Certification")]
        public virtual Certification Certification { get; set; }

        [Display(Name="DateCertification")]
        public DateTime DateCertification { get; set; }

    }
}