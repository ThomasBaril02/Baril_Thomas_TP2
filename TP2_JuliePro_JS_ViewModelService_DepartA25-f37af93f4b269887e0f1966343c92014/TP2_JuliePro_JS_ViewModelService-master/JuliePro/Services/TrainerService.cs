using JuliePro.Data;
using JuliePro.Models;
using JuliePro.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            //int pageIndex = filter.SelectedPageIndex;
            //int pageSize = filter.SelectedPageSize;

            //TODO: Ajouter les filtres
            IQueryable<Trainer> filtre = _dbContext.Trainers
                .Include(t => t.Discipline)
                .Include(t => t.TrainerCertifications)
                    .ThenInclude(tc => tc.Certification);

            if (!string.IsNullOrWhiteSpace(filter.SearchNameText))
            {
                string search = filter.SearchNameText.ToLower();
                filtre = filtre.Where(t =>
                    t.FirstName.ToLower().Contains(search) ||
                    t.LastName.ToLower().Contains(search) ||
                    (t.Discipline != null && t.Discipline.Name.ToLower().Contains(search))
                );
            }
            
            if (filter.SelectedDisciplineId.HasValue && filter.SelectedDisciplineId.Value > 0)
            {
                filtre = filtre.Where(t => t.Discipline_Id == filter.SelectedDisciplineId.Value);
            }

            if (filter.SelectedCertificationId.HasValue && filter.SelectedCertificationId.Value > 0)
            {
                filtre = filtre.Where(t => t.TrainerCertifications.Any(tc => tc.Certification_Id == filter.SelectedCertificationId.Value));
            }


            result.Items = await _dbContext.Trainers.ToPaginatedAsync(pageIndex, pageSize);

            //TODO: Ajouter les éléments dans les SelectLists 
            result.AvailablePageSizes = new SelectList(new List<int>() { 9, 12, 18, 21 });
            result.Disciplines = new SelectList(new List<Discipline>(), "Id", "Name");
            result.Certifications = new SelectList(new List<Certification>(), "Id", "FullTitle");
            result.CertificationCenters = new SelectList(new List<string>());

            return result;
        }
    }
}
