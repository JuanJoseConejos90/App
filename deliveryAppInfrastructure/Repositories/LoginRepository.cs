using deliveryAppCore.Entities;
using deliveryAppCore.Interfaces;
using deliveryAppCore.Responses;
using deliveryAppInfrastructure.DataAccess;
using deliveryAppInfrastructure.utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace deliveryAppInfrastructure.Repositories
{
    public class LoginRepository : ILogin
    {
        private readonly deliveryDbContext _context;
        protected readonly DbSet<User> _entity;
        private readonly ILogger<User> _logger;
        public LoginRepository(deliveryDbContext context, ILogger<User> logger)
        {
            _context = context;
            _entity = _context.Set<User>();
            _logger = logger;
        }

        public async Task<LoginResponse> Login(User req)
        {

            LoginResponse response = null;

            try
            {

                BCryptUtil BC = new BCryptUtil();
                jwtTokens jwt = new jwtTokens();
                var userName = await _entity.SingleOrDefaultAsync(x => x.User1.TrimEnd() == req.User1.TrimEnd());
                if (userName != null)
                {
                    if (BC.verifyPass(req.Pass, userName.Pass))
                    {
                        response = new LoginResponse();
                        response.name = userName.User1;
                        response.Token = jwt.GenerateJSONWebToken(userName);
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogInformation(String.Format("Error: {0}", ex.Message));
            }

            return await Task.FromResult(response);
        }

        public async Task<bool> SignUp(User req)
        {
            Boolean resp = false;

            try
            {
                var userName = await _entity.SingleOrDefaultAsync(x => x.User1 == req.User1);

                if (userName == null)
                {
                    BCryptUtil BC = new BCryptUtil();
                    req.Pass = BC.generatePassBCryt(req.Pass);
                    await Task.FromResult(_entity.Add(req));
                    int save = await _context.SaveChangesAsync();
                    resp = save > 0;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(String.Format("Error: {0}", ex.Message));
            }

            return resp;
        }
    }
}
