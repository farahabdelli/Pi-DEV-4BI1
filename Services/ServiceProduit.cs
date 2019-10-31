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
    public class ServiceProduit: Service<Product>, IServiceProduit
    {
        private static DatabaseFactory dbf = new DatabaseFactory();

        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceProduit():base(uow)
        {



        }
      
        public IEnumerable<Product> GetMostExpensiveProduct()
        {
            //return GetMany().OrderByDescending(p => p.Price).Take(5);
            IEnumerable<Product> req = from p in GetMany()
                                       orderby p.Prix descending
                                       select p;
            return req.Take(5);
        }

        public IEnumerable<Product> mobile()
        {
            
            return GetMany(p => p.Categorie.Nom.Equals("Smartphone"));
        }

        public IEnumerable<Product> Tablet()
        {

            return GetMany(p => p.Categorie.Nom.Equals("Tablet"));
        }

        public IEnumerable<Product> ADSL()
        {

            return GetMany(p => p.Categorie.Nom.Equals("ADSL"));
        }

        public IEnumerable<Product> Flybox()
        {

            return GetMany(p => p.Categorie.Nom.Equals("Flybox"));
        }


    }
}

