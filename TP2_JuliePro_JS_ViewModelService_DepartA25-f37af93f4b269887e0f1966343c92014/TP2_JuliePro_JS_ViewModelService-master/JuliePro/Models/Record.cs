using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuliePro.Models
{
    public class Record
    {
        [Display(Name = "Id")] 
        public int Id { get; set; }
        
        [Display(Name = "Date")] 
        public DateTime Date { get; set; }

        [ForeignKey("Discipline")]
        [Display(Name = "Discipline_Id")] 
        public int? Discipline_Id { get; set; }

        [Display(Name = "Discipline")]
        public virtual Discipline Discipline { get; set; }

        [Display(Name = "Amount")]
        [Range(0, 10000)]
        public Decimal Amount { get; set; }

        [Display(Name = "Unit")]
        [StringLength(50, MinimumLength = 1)]
        public string Unit { get; set; }

        [ForeignKey("Trainer")]
        [Display(Name = "Trainer_Id")] 
        public int? Trainer_Id { get; set; }

        [Display(Name = "Trainer")] 
        public virtual Trainer Trainer { get; set; }
    }
}