using Adverts.Core;
using Adverts.Core.Models.Domains;
using Adverts.Core.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Persistence
{
    public class Image : IImage
    {
        private IWebHostEnvironment _env;
        public Image(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> UploadImage(string folderPath, IFormFile formFile)
        {
            folderPath += $"{Guid.NewGuid()}{formFile.FileName}";
            string serverFolder = Path.Combine(_env.WebRootPath, folderPath);
            await formFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return $@"\{folderPath}";
        }

        public async Task UploadImages(AdvertViewModel vm)
        {
            if (vm.MainImageFile != null)
            {
                string folderPath = @"adverts\images\";
                vm.Advert.MainImageUrl = await UploadImage(folderPath, vm.MainImageFile);
            }

            if (vm.FileGalleries.Any())
            {
                string folderPath = @"adverts\gallery\";
                vm.Advert.AdvertGalleries = new Collection<AdvertGallery>();

                foreach (var file in vm.FileGalleries)
                {
                    vm.Advert.AdvertGalleries.Add(new AdvertGallery
                    {
                        Name = file.FileName,
                        Url = await UploadImage(folderPath, file)
                    });
                }
            }
        }
    }
}
