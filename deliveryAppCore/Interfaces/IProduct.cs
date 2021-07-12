using deliveryAppCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliveryAppCore.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> getAllProducts();
        Task<Product> getProduct(int id);
        Task<Boolean> InsertProduct(Product req);
        Task<Boolean> UpdateProduct(Product req);
        Task<Boolean> DeletetProduct(int id);
    }
}
