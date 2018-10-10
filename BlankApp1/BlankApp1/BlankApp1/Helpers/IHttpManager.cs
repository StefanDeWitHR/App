using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public interface IHttpManager
    {
        Task<string> Post<T>(T DTO, string url);
        Task<T> Get<T>(string url);
        Task<bool> Put<T>(T DTO, string url);
    }
}
