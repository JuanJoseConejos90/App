using deliveryAppCore.Entities;
using deliveryAppCore.Interfaces;
using deliveryAppInfrastructure.DataAccess;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace deliveryAppInfrastructure.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly deliveryDbContext _context;
        protected readonly DbSet<Product> _entity;
        private readonly ILogger<Product> _logger;
        public ProductRepository(deliveryDbContext context, ILogger<Product> logger)
        {
            _context = context;
            _entity = _context.Set<Product>();
            _logger = logger;
        }
        public async Task<bool> DeletetProduct(int id)
        {
            Boolean resp = false;

            try
            {
                Product p = await getProduct(id);
                await Task.FromResult(_entity.Remove(p));
                int save = await _context.SaveChangesAsync();
                resp = save > 0;
            }
            catch (Exception ex)
            {

                _logger.LogInformation(String.Format("Error: {0}", ex.Message));
            }

            return resp;
        }

        public async Task<IEnumerable<Product>> getAllProducts()
        {
            return await _entity.ToListAsync();
        }

        public async Task<Product> getProduct(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<bool> InsertProduct(Product req)
        {
            Boolean resp = false;

            try
            {
                await Task.FromResult(_entity.Add(req));
                int save = await _context.SaveChangesAsync();
                resp = save > 0;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(String.Format("Error: {0}", ex.Message));
            }

            return resp;
        }

        public async Task<bool> UpdatetProduct(Product req)
        {
            Boolean resp = false;

            try
            {
                await Task.FromResult(_entity.Update(req));
                int save = _context.SaveChanges();
                resp = save > 0;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(String.Format("Error: {0}", ex.Message));
            }

            return resp;
        }
    }
}
