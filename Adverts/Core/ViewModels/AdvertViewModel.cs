using Adverts.Core.Models.Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Core.ViewModels
{
    public class AdvertViewModel
    {
        public AdvertViewModel()
        {
            FileGalleries = new FormFileCollection();
        }
        public Advert Advert { get; set; }

        [Required(ErrorMessage = "Pole kategoria jest wymagane")]
        [Display(Name = "Kategoria")]
        public int? CategoryId { get; set; }
        public IEnumerable<Product> Products { get; set; }

        [Display(Name = "Wybierz zdjęcie główne")]
        public IFormFile MainImageFile { get; set; }

        [Display(Name = "Wybierz dodatkowe zdjęcia")]
        public IFormFileCollection FileGalleries { get; set; }
    }
}
