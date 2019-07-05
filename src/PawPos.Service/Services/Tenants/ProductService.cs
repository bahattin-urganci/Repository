using PawPos.Domain;
using PawPos.Domain.Product;
using PawPos.Infrastructure.Attributes;
using PawPos.Model;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service.Services.Tenants
{
    [Transient]
    public class ProductService : BaseService, IProductService
    {
        IProductRepository _productRepository;
        ISectionRepository _sectionRepository;

        public ProductService(IProductRepository productRepository, ISectionRepository sectionRepository)
        {
            _productRepository = productRepository;
            _sectionRepository = sectionRepository;
        }

        public async Task<Product> GetProduct(string id) => await _productRepository.GetAsync(x => x.Id == id);

        public async Task<Dictionary<string, List<Product>>> Menu()
        {
            var products = await Products();
            var menu = products.GroupBy(x => x.Group);
            return menu.ToDictionary(x => x.Key, x => x.ToList());

        }

        public async Task<List<Product>> Products() => (await _productRepository.GetAllAsync()).ToList();

        public Task RemoveProduct(Product product) => _productRepository.RemoveAsync(product);

        public async Task<ActionResponse<Product>> SaveProduct(Product productDTO)
        {
            var response = CreateResponse(productDTO);
            response.Response.Id = await _productRepository.SaveAsync(response.Response);
            return response;

        }

        public async Task<Section> GetSection(string id) => await _sectionRepository.GetAsync(x => x.Id == id);
        public async Task<List<Section>> Sections() => (await _sectionRepository.GetAllAsync()).ToList();
        public async Task<ActionResponse<Section>> SaveSection(Section section)
        {
            var response = CreateResponse(section);
            response.Response.Id = await _sectionRepository.SaveAsync(section);
            return response;
        }
        public async Task RemoveSection(Section section)
        {
            var products = await _productRepository.FindAsync(x => x.SectionId == section.Id);
            await _productRepository.RemoveRangeAsync(products);
        }


    }
}
