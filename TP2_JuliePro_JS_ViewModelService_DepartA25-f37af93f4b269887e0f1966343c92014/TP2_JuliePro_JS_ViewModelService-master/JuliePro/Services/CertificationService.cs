using JuliePro.Data;
using JuliePro.Models;
using Microsoft.EntityFrameworkCore;

namespace JuliePro.Services
{
    public class CertificationService : ServiceBaseEF<Certification>
    {
        public CertificationService(JulieProDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TrainerCertificationViewModel> GetAllByTrainerAsync(int trainerId)
        {
            var trainer = await _dbContext.Trainers.FindAsync(trainerId);
            var model = await _dbContext.Certifications.Where(x => x.TrainerCertifications.Any(y => y.Trainer_Id == trainerId)).ToListAsync();

            return new TrainerCertificationViewModel(trainer, model);
        }
    }
}
