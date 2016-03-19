using System.Linq;
	
namespace ProductSample.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => !p.IsDeleted);
        }

        public IQueryable<Product> All(bool isAll)
        {
            if (isAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
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