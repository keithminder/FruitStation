using FruitStation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStation.Domain.Repositories.Abstact
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAllByDates(DateTime startDate, DateTime endDate);


        void Save(Sale sale);
    }
}
