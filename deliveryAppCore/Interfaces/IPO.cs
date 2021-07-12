using deliveryAppCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface IPO
    {
        Task<Boolean> InsertPOS(Po req);
    }
}
