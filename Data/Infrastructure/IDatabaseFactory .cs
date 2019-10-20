using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        projetPIContext DataContext { get; }
    }

}
