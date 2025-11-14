using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models
{
    public enum Genre
    {
        [Display(Name="Neutral")]
        Neutral=2,

        [Display(Name = "Female")]
        Female =1,

        [Display(Name = "Male")]
        Male =0
    }
}