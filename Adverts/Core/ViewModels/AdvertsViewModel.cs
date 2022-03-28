using Adverts.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Core.ViewModels
{
    public class AdvertsViewModel
    {
        public string Title { get; set; }
        public string UserId { get; set; }
        public IEnumerable<Advert> Adverts { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public int ConditionId { get; set; }
        public IEnumerable<Condition> Conditions { get; set; }

        [Display(Name = "Tylko moje ogłoszenia")]
        public bool IsMyAdverts { get; set; }
    }
}
