using FruitStation.Domain.Entities;
using FruitStation.Domain.Repositories.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStation.Domain.Repositories.Concrete
{
    public class InMemoryFruitRepository : IFruitRepository
    {


        private void initializeFruits()
        {
            AppDomain.CurrentDomain.SetData("fruits", FruitList.Fruits);
        }

        public IEnumerable<Fruit> GetAll()
        {
            if (AppDomain.CurrentDomain.GetData("fruits")==null)
            {
                initializeFruits();
            }
            return (IEnumerable<Fruit>)AppDomain.CurrentDomain.GetData("fruits");
        }


        public Fruit Get(int fruitID)
        {
            return GetAll().Single(f=>f.ID==fruitID);
        }
    }
}
