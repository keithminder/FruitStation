using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitStation.Web.Models
{
    public class SaleEntryModel
    {
        public IEnumerable<Domain.Entities.Fruit> Fruits { get; set; }

        public IEnumerable<Domain.Entities.Sale> Sales { get; set; }
    }
}
