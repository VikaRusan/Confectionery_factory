using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confectionery_factory
{
    internal class ProductsClass
    {
        public IEnumerable<Изделия> GetAllProducts()
        {
            var context = new Кондитерская_фабрикаEntities1();
            return context.Изделия.Include("Категории").ToList();
        }
    }
}
