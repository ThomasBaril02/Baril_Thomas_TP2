using JuliePro.Data;
using JuliePro.Models;
using JuliePro.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JuliePro.Services
{
    public class TrainerService : ServiceBaseEF<Trainer>
    {
        private IImageFileManager fileManager;

        public TrainerService(JulieProDbContext dbContext, IImageFileManager fileManager) : base(dbContext)
        {
            this.fileManager = fileManager;
        }

        public async Task<Trainer> CreateAsync(Trainer model, IFormCollection form)
        {
            model.Photo = await fileManager.UploadImage(form, false, null);

            return await base.CreateAsync(model);
        }

        public async Task EditAsync(Trainer model, IFormCollection form)
        {
            var old = await _dbContext.Trainers.Where(x => x.Id == model.Id).Select(x => x.Photo).FirstOrDefaultAsync();
            model.Photo = await fileManager.UploadImage(form, true, old);
            await EditAsync(model);
        }

        public async Task<TrainerSearchViewModel> GetAllAsync(TrainerSearchViewModelFilter filter)
        {
            filter.VerifyProperties();//mets à null les éléments qui sont vides. 

            var result = new TrainerSearchViewModel(filter);

            // Pour l'instant, on affiche tout sur la même page, car la pagination n'est pas encore fonctionnel
            int pageIndex = filter.SelectedPageIndex;
            int pageSize = filter.SelectedPageSize;
            // TODO: Remplacer par ce code une fois que vous commencez à implémenter la pagination

            //TODO: Ajouter les filtres
            IQueryable<Trainer> b = _dbContext.Trainers.Include(a=>a.TrainerCertifications).ThenInclude(a=>a.Certification);
            
            if (!result.SearchNameText.IsNullOrEmpty())
            {
                b  = b.Where(a => a.FirstName.Contains(result.SearchNameText) || a.LastName.Contains(result.SearchNameText));
            }
            if (result.SelectedGender != null)
            {
                b = b.Where(a=>a.Genre == result.SelectedGender);
            }
            if (result.SelectedDisciplineId.HasValue)
            {
                b = b.Where(a => a.Discipline_Id == result.SelectedDisciplineId);
            }
            if (result.SelectedCertificationId.HasValue)
            {
                b = b.Where(a => a.TrainerCertifications.Any(a => a.Certification_Id == result.SelectedCertificationId));
            }
            if (!result.SelectedCertificationCenter.IsNullOrEmpty())
            {
                b = b.Where(a => a.TrainerCertifications.Any(a => a.Certification.CertificationCenter == result.SelectedCertificationCenter));
            }
            result.Items = await b.ToPaginatedAsync(pageIndex, pageSize);
            //TODO: Ajouter les éléments dans les SelectLists 
            result.AvailablePageSizes = new SelectList(new List<int>() { 9, 12, 18, 21 });
            result.Disciplines = new SelectList(_dbContext.Disciplines, "Id", "Name");
            result.Certifications = new SelectList(_dbContext.Certifications, "Id", "FullTitle");
            result.CertificationCenters = new SelectList(_dbContext.Certifications.Select(a=>a.CertificationCenter).Distinct().ToList());

            return result;
        }
    }
}
