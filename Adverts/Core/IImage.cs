using Adverts.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Adverts.Core
{
    public interface IImage
    {
        Task UploadImages(AdvertViewModel vm);
    }
}