using Data.Infrastructure;
using Domaine;
using MyFinance.Data.Infrastructure;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public  class ServiceProductStores : Service<ProductStore>, IServiceProductStores
    {

    
   
            private static DatabaseFactory dbf = new DatabaseFactory();

            private static IUnitOfWork uow = new UnitOfWork(dbf);
            public ServiceProductStores() : base(uow)
            {



            }

        /*  public IEnumerable<ProductStore> Getlist()
          {
              //return GetMany().OrderByDescending(p => p.Price).Take(5);
              IEnumerable<ProductStore> req = from p in GetMany()
                                         orderby p.Prix descending
                                         select p;
              return req.Take(5);
          }*/

        public IEnumerable<ProductStore> list(int id)
        {
            IEnumerable<ProductStore> req = from p in GetMany()
                                            where p.Productt.ProduitId == id
                                            select p;
            return req;
        }
    }
}
