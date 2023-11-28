using ElectroPc_Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroPc_Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository productRepository { get; }

        Task Save();
    }
}
