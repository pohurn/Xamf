using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamf.Models;
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

        public async Task<Recipe> GetAllRecipes(int pagesize) {

            Recipe RecipesReceived = new Recipe();

            try
            {
                RecipesReceived = await _requestProvider.GetAsync<Recipe>(Constants.SERVER_URL + "?p=" + pagesize);
            }
            catch
            {
                RecipesReceived = null;
                throw;
            }
            return RecipesReceived;
        }
    }
}
