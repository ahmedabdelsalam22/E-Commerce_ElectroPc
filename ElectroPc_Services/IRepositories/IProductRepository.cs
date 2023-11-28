using ElectroPc_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroPc_Services.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void Update(Product product);
    }
}
