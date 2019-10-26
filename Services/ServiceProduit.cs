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
    public class ServiceProduit: Service<Produit>, IServiceProduit
    {
        private static DatabaseFactory dbf = new DatabaseFactory();

        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceProduit():base(uow)
        {



        }
        public IEnumerable<Produit> GetProductsbyCategoryname(String catname)
        {//lambda
         // return  GetMany(p => p.Category.Name.Equals(catname));
         //linq
            IEnumerable<Produit> req = from p in GetMany()
                                       where p.Categorie.Nom == catname
                                       select p;
            return req;


        }
        public IEnumerable<Produit> GetMostExpensiveProduct()
        {
            //return GetMany().OrderByDescending(p => p.Price).Take(5);
            IEnumerable<Produit> req = from p in GetMany()
                                       orderby p.Prix descending
                                       select p;
            return req.Take(5);
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

