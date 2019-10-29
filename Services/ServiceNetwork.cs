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
    public class ServiceNetwork : Service<Network>, IServiceNetwork
    {
        private static DatabaseFactory dbf = new DatabaseFactory();

        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceNetwork():base(uow)
        { }


        public void AddNetwork(Network c)
        {
            //ctx.Categories.Add(c);
            //ctx.Set<Category>().Add(c);
            // repo.add(c);
            uow.getRepository<Network>().Add(c);


        }

        public void RemoveNetwork(Network c)
        {
            //ctx.Categories.Remove(c);
            //ctx.Set<Category>().Remove(c);
            //repo.Delete(c);
            uow.getRepository<Network>().Delete(c);
        }



        /* public IEnumerable<string> GetProductbyClient(Client c)
         {
             var req = from f in uow.getRepository<Facture>().GetMany()
                       where f.Client.Cin == c.Cin
                       select f.Product.Name;
             return req;

         }*/

    }
}

