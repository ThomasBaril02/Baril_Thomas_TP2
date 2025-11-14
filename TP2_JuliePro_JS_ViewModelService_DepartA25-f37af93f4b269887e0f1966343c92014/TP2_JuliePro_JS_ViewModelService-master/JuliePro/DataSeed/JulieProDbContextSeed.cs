using JuliePro.Data;
using JuliePro.Models;
using JuliePro.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro.DataSeed
{
    public class JulieProDbContextSeed : IJulieProDbContextSeed
    {
        private ILogger<JulieProDbContextSeed> logger;
        protected JulieProDbContext context;
        protected string wwwrootImagePath;

        public JulieProDbContextSeed(ILogger<JulieProDbContextSeed> logger, JulieProDbContext context, string wwwrootImagePath)
        {
            this.logger = logger;
            this.context = context;
            this.wwwrootImagePath = wwwrootImagePath;

        }

        public JulieProDbContextSeed(ILogger<JulieProDbContextSeed> logger, JulieProDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task SeedAsync(int retry = 0)
        {
            var retryForAvailability = retry;

            try
            {
                if (context.Database.IsSqlServer())
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;

                logger.LogError(EventCode.ErrorTransient, ex.Message);
                await this.SeedAsync(retryForAvailability);

                throw;
            }

            try
            {
                if (!await context.Certifications.AnyAsync())
                {
                    await context.Certifications.AddRangeAsync(GetCertifications());
                    await context.SaveChangesAsync();
                }

                if (!await context.Disciplines.AnyAsync())
                {
                    await context.Disciplines.AddRangeAsync(GetDisciplines());
                    await context.SaveChangesAsync();
                }

                if (!await context.Trainers.AnyAsync())
                {
                    await context.Trainers.AddRangeAsync(GetTrainers());
                    await context.SaveChangesAsync();
                }

                if (!await context.TrainerCertifications.AnyAsync())
                {
                    await context.TrainerCertifications.AddRangeAsync(GetTrainerCertifications());
                    await context.SaveChangesAsync();
                }

                if (!await context.Records.AnyAsync())
                {
                    await context.Records.AddRangeAsync(GetRecords());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(EventCode.ErrorDb, ex, ex.Message);
                throw;
            }
        }
        protected virtual List<Trainer> GetTrainers() => new();
        protected virtual List<Certification> GetCertifications() => new();
        protected virtual List<Discipline> GetDisciplines() => new();

        protected virtual List<TrainerCertification> GetTrainerCertifications() => new();
        protected virtual List<Record> GetRecords() => new();


    }

}
