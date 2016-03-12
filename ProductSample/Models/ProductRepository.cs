using System;
using System.Linq;
using System.Collections.Generic;
	
namespace ProductSample.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => !p.IsDeleted);
        }

        public Product Find(int? id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }
        
    }

	public  interface IProductRepository : IRepository<Product>
	{

    }
}