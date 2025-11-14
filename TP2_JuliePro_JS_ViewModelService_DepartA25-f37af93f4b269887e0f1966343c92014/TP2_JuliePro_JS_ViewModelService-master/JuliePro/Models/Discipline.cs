using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuliePro.Models
{
    public class Discipline
    {
        [Display(Name="Id")]
        public int Id { get; set; }

        [Display(Name="Name")]
        public string Name { get; set; }

        [Display(Name="Description")]
        public string Description { get; set; }

        [Display(Name="TrainerPersonalRecords")]
        public virtual ICollection<Record> TrainerPersonalRecords { get; set; }

        [Display(Name="Trainers")]
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}