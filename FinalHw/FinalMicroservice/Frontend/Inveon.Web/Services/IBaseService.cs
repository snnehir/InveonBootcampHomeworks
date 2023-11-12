using Inveon.Web.Models;
using Inveon.Web.Models.Dto;

namespace Inveon.Web.Services
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
