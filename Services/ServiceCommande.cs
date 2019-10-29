using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domaine;
using Service.Pattern;

namespace Services
{
    public class ServiceCommande : Service<Commande>, IServiceCommande
    {
        public ServiceCommande(IUnitOfWork utwk) : base(utwk)
        {
            ServiceCommande sc = new ServiceCommande(utwk);
        }
    }
     
}
