using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace xamf.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri);

        Task<TResult> PostAsync<TResult>(string uri, TResult data);

        Task<TResult> PostAsync<TResult>(string uri, string data);
    }
}
