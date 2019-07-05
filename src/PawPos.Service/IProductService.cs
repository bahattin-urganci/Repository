
using PawPos.Domain;
using PawPos.Domain.Product;
using PawPos.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service
{
    public interface IProductService
    {
        Task<List<Product>> Products();
        Task<ActionResponse<Product>> SaveProduct(Product productDTO);
        Task RemoveProduct(Product product);
        Task<Product> GetProduct(string id);
        Task<Dictionary<string, List<Product>>> Menu();
        Task<List<Section>> Sections();
        Task<ActionResponse<Section>> SaveSection(Section section);
        Task RemoveSection(Section section);
        Task<Section> GetSection(string id);
    }
}
