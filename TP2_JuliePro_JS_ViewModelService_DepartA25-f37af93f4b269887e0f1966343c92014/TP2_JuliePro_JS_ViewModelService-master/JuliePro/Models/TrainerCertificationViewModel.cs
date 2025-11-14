namespace JuliePro.Models
{
    public class TrainerCertificationViewModel
    {
        public TrainerCertificationViewModel()
        {

        }

        public TrainerCertificationViewModel(Trainer trainer, IEnumerable<Certification> certifications)
        {
            Trainer = trainer;
            Certifications = certifications;
        }

        public Trainer Trainer { get; set; }
        public IEnumerable<Certification> Certifications { get; set; }

    }
}
