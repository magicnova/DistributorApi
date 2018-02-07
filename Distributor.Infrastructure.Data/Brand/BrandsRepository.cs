using System.Collections.Generic;
using System.Linq;
using Distributor.Domain;
using Distributor.Infrastructure.Data.Context.Interfaces;
using Distributor.Infrastructure.Data.Schemas;
using MongoDB.Driver;

namespace Distributor.Infrastructure.Data.Brand
{
    public class BrandsRepository :IBrandsRepository
    {
        private readonly IDistributorContext _distributorContext;

        public BrandsRepository(IDistributorContext distributorContext)
        {
            _distributorContext = distributorContext;
        }

        public IList<Brands> GetActiveBrands()
        {
            var filterActiveBrands = Builders<BrandsSchema>.Filter.Eq("Active", true);
                
            var brands = _distributorContext.GetContext().GetCollection<BrandsSchema>("brands")
                .Find(filterActiveBrands).ToList();


            return brands.Select(brand =>  (Brands)brand.BrandId).ToList();
        }
    }
}