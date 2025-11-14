using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro.Utility
{

    public interface IImageFileManager
    {
        Task<string?> UploadImage(IFormCollection form, bool Edit, string? oldImage = null);
    }


    public class ImageFileManager : IImageFileManager
    {
        private IWebHostEnvironment webHostEnvironment;
        private ILogger<ImageFileManager> logger;

        public ImageFileManager(ILogger<ImageFileManager> logger, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.logger = logger;
        }

        public async Task<string?> UploadImage(IFormCollection form, bool Edit, string? oldImage = null)
        {
            var files = form.Files; //nouvelle image récupérée

            if (files.Count > 0)
            {
                string webRootPath = webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString();// Nom fichier généré, unique
                var uploads = webRootPath + AppConstants.ImagePath;// chemin pour les image
                var extension = Path.GetExtension(files[0].FileName); // extraire l'extension du fichier

                // Create un cannal pour transférer le fichier 
                using (var filesStreams = new FileStream(uploads + fileName + extension, FileMode.Create))
                {
                    await files[0].CopyToAsync(filesStreams);
                }

                // Je supprime l'ancien fichier si c'est une édition

                if (Edit && !String.IsNullOrWhiteSpace(oldImage))
                {
                    try
                    {
                        File.Delete(uploads + oldImage);

                    }
                    catch (Exception ex)
                    {
                        this.logger.LogError(EventCode.ErrorIO, "Error while deleting for {uploads}{oldImagePath}", uploads, oldImage);
                    }
                }

                return fileName + extension;
            }
            return oldImage;
        }


    }
}
