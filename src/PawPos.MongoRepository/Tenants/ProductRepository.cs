using PawPos.Domain.Product;
using PawPos.Infrastructure.Attributes;
using PawPos.Repository;

namespace PawPos.MongoRepository.Tenants
{
    [Transient]    
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        
        public ProductRepository(IDatabaseFinder dbFinder)
        {   
            SetConnection(dbFinder.GetDbSettings());
        }
    }
}
