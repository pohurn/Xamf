using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace xamf.Services
{
    public interface IApiService
    {
        Task<string> GetName();
    }
}
