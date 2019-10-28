using Domaine;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

namespace Services
{
    public class ServiceBills : Service<Bill>, IServiceBill
    {
        public ServiceBills(IUnitOfWork utwk) : base(utwk)
        {
        }
    }
}
