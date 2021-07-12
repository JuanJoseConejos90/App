using AppCore.Interfaces;
using deliveryAppCore.Entities;
using deliveryAppInfrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AppInfrastructure.Repositories
{
    public class PoRepository : IPO
    {
        private readonly deliveryDbContext _context;
        protected readonly DbSet<Po> _entity;
        private readonly ILogger<Po> _logger;
        public PoRepository(deliveryDbContext context, ILogger<Po> logger)
        {
            _context = context;
            _entity = _context.Set<Po>();
            _logger = logger;
        }

        public async Task<bool> InsertPOS(Po req)
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
    }
}
