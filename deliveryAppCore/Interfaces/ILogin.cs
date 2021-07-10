using deliveryAppCore.Entities;
using deliveryAppCore.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliveryAppCore.Interfaces
{
    public interface ILogin
    {
        Task<LoginResponse> Login(User req);
        Task<Boolean> SignUp(User req);
    }
}
