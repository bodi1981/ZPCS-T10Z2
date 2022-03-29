using Adverts.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Adverts.Core
{
    public interface IImage
    {
        Task<string> UploadImage(string folderPath, IFormFile formFile);
        Task UploadImages(AdvertViewModel vm);
    }
}