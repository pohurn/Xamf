using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamf.Models;

namespace xamf.Services
{
    public interface IApiService
    {
        Task<Recipe> GetAllRecipes(int pagesize);
    }
}
