using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuliePro.Models
{
    public class Trainer
    {
        [Display(Name="Id")]
        public int Id { get; set; }

        [Required()]
        [StringLength(25, MinimumLength = 1)]
        [Display(Name="FirstName")]
        public string FirstName { get; set; }

        [Required()]
        [StringLength(25, MinimumLength = 1)]
        [Display(Name="LastName")]
        public string LastName { get; set; }

        public string FullName { get { return this.FirstName + " " + this.LastName; } }

        [Display(Name="Biography")]
        public string Biography { get; set; }

        [Display(Name="Genre")]
        public Genre Genre { get; set; }

        [Required()]
        [EmailAddress()]
        [Display(Name="Email")]
        public string Email { get; set; }

        [StringLength(40)]
        [Display(Name="Photo")]
        public string? Photo { get; set; }

        [Display(Name="Active")]
        public bool Active { get; set; } = false;

        [ForeignKey("Discipline")]
        [Display(Name="Discipline_Id")]
        public int Discipline_Id { get; set; }
        
        [Display(Name="Discipline")]
        public virtual Discipline Discipline { get; set; }

        [Display(Name="TrainerCertifications")]
        public virtual ICollection<TrainerCertification> TrainerCertifications { get; set; }

        [Display(Name="Records")]
        public virtual ICollection<Record> Records { get; set; }
    }
}