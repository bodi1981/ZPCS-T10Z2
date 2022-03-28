using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Core.Models.Domains
{
    public class AdvertGallery
    {
        public int Id { get; set; }
        public int AdvertId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Advert Advert { get; set; }
    }
}
