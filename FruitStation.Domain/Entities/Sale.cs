using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitStation.Domain.Entities
{
    public class Sale
    {
        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double ExtendedPrice { get { return Quantity * UnitPrice; } }
        public Fruit Fruit { get; set; }

        public DateTime EnteredOn { get; set; }
    }
}
