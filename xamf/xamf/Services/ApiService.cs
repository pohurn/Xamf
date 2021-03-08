using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamf.Services.RequestProvider;

namespace xamf.Services
{
    class ApiService : IApiService
    {
        private readonly IRequestProvider _requestProvider;

        public ApiService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<string> GetName() {

            string name = string.Empty;

            try
            {
                //call api here
                name = "Navin";
            }
            catch
            {
                name = string.Empty;
                throw;
            }
            return name;
        }
    }
}
