using Inveon.Web.Models;

namespace Inveon.Web.Services.Product
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.POST,
                Data = productDto,
                Url = StaticDefinitions.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.DELETE,
                Url = StaticDefinitions.ProductAPIBase + "/api/products/" + id,
                AccessToken = token
            });
        }


        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.GET,
                Url = StaticDefinitions.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.GET,
                Url = StaticDefinitions.ProductAPIBase + "/api/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.PUT,
                Data = productDto,
                Url = StaticDefinitions.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }
    }

}
