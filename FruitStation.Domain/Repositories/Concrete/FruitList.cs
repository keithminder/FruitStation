using FruitStation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStation.Domain.Repositories.Concrete
{
    public class FruitList
    {
        static IEnumerable<Fruit> fruits = new List<Fruit>{
                 new Fruit{ID=0, Name="Apple"}
                ,new Fruit{ID=1, Name="Banana"}
                ,new Fruit{ID=2, Name="Orange"}
                ,new Fruit{ID=3, Name="Pear"}
                ,new Fruit{ID=4, Name="Watermelon"}
            };
        public static IEnumerable<Fruit> Fruits
        {
            get { return fruits; } 
        }
    }
}
