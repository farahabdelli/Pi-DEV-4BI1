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
    class ServicePromotion : Service<Promotion>, IServicePromotion
    {
        private static DatabaseFactory dbf = new DatabaseFactory();

        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServicePromotion() : base(uow)
        { }


    }
}
