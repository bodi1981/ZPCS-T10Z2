using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Core.Models.Domains
{
    public class Condition
    {
        public Condition()
        {
            Adverts = new Collection<Advert>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Advert> Adverts { get; set; }
    }
}
