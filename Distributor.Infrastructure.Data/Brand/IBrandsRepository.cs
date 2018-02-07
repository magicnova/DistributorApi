using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure.Data.Brand
{
    public interface IBrandsRepository
    {
        IList<Brands> GetActiveBrands();
    }
}