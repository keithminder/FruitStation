using FruitStation.Domain.Entities;
using FruitStation.Domain.Repositories.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStation.Domain.Repositories.Concrete
{
    public class InMemorySaleRepository : ISaleRepository
    {


        private void initializeSales()
        {
            List<Sale> sales = GenerateSales();

            AppDomain.CurrentDomain.SetData("sales", sales.AsEnumerable());
      
        }

        private static List<Sale> GenerateSales()
        {
            var fruits = FruitList.Fruits.ToList();
            List<Sale> sales = new List<Sale>();

            for (int days = 0; days < 90; days++)
            {
                for (int quantity = 1; quantity < 17; quantity++)
                {
                    sales.AddRange(fruits.Select(f => new Sale
                    {
                        Quantity = quantity + days
                        ,
                        EnteredOn = DateTime.Now.AddDays(-days)
                        ,
                        Fruit = f
                        ,
                        UnitPrice = (days * .03) + (fruits.IndexOf(f) + 1) * .07 + (.32 + fruits.IndexOf(f) * .04)
                    }));
                }
            }
            return sales;
        }

        public IEnumerable<Sale> GetAll()
        {

            return getSales();
        }

        private IEnumerable<Sale> getSales()
        {
            if (AppDomain.CurrentDomain.GetData("sales") == null)
            {
                initializeSales();
            }
            return (IEnumerable<Sale>)AppDomain.CurrentDomain.GetData("sales");
        }

        public IEnumerable<Sale> GetAllByDates(DateTime startDate, DateTime endDate)
        {
           return getSales().Where(s=>s.EnteredOn.Date>=startDate&&s.EnteredOn.Date<=endDate);
        }


        public void Save(Sale sale)
        {
            var sales = getSales().ToList();
            sales.Add(sale);
            AppDomain.CurrentDomain.SetData("sales", sales.AsEnumerable());

        }
    }
}
