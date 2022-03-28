using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Core.Models.Domains
{
    public class Advert
    {
        public Advert()
        {
            AdvertGalleries = new Collection<AdvertGallery>();
        }
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Pole tytuł jest wymagane")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pole produkt jest wymagane")]
        [Display(Name = "Produkt")]
        public int? ProductId { get; set; }

        [MaxLength(250)]
        [Required(ErrorMessage = "Pole opis jest wymagane")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Pole stan jest wymagane")]
        [Display(Name = "Stan")]
        public int? ConditionId { get; set; }

        [AllowNull]
        public string MainImageUrl { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data ważności ogłoszenia")]
        public DateTime? DateValid { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public Product Product { get; set; }
        public Condition Condition { get; set; }

        public ICollection<AdvertGallery> AdvertGalleries { get; set; }
    }
}
