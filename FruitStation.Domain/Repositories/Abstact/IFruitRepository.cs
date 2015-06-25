using FruitStation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStation.Domain.Repositories.Abstact
{
    public interface IFruitRepository
    {
        IEnumerable<Fruit>GetAll();

        Fruit Get(int p);
    }
}
