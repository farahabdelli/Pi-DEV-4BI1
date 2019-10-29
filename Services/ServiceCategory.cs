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
    public class ServiceCategory : Service<Category>, IServiceCategory
    {
        private static DatabaseFactory dbf = new DatabaseFactory();

        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceCategory():base(uow)
        {



        }


        public void AddCategory(Category c)
        {
            //ctx.Categories.Add(c);
            //ctx.Set<Category>().Add(c);
            // repo.add(c);
            uow.getRepository<Category>().Add(c);


        }

        public void RemoveCategory(Category c)
        {
            //ctx.Categories.Remove(c);
            //ctx.Set<Category>().Remove(c);
            //repo.Delete(c);
            uow.getRepository<Category>().Delete(c);
        }

    }
}

