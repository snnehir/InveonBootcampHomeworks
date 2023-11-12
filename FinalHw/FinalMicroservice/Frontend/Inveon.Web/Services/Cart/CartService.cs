using Inveon.Web.Models;
using Inveon.Web.Models.Dto;

namespace Inveon.Web.Services.Cart
{
    public class CartService : BaseService, ICartService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CartService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }




        public async Task<T> AddToCartAsync2<T>(CartDto cartDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.POST,
                Data = cartDto,
                Url = StaticDefinitions.ShoppingCartAPIBase + "/api/cart",
                AccessToken = token
            });
        }

        public async Task<T> ApplyCoupon<T>(CartDto cartDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.POST,
                Data = cartDto,
                Url = StaticDefinitions.ShoppingCartAPIBase + "/api/cart/ApplyCoupon",
                AccessToken = token
            });
        }

        public async Task<T> Checkout<T>(CartHeaderDto cartHeader, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.POST,
                Data = cartHeader,
                Url = StaticDefinitions.ShoppingCartAPIBase + "/api/cartc",
                AccessToken = token
            });
        }



        public async Task<T> GetCartByUserIdAsnyc<T>(string userId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.GET,
                Url = StaticDefinitions.ShoppingCartAPIBase + "/api/cart/GetCart/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> RemoveCoupon<T>(string userId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.POST,
                Data = userId,
                Url = StaticDefinitions.ShoppingCartAPIBase + "/api/cart/RemoveCoupon",
                AccessToken = token
            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.POST,
                Data = cartId,
                Url = StaticDefinitions.ShoppingCartAPIBase + "/api/cart/RemoveCart",
                AccessToken = token
            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDefinitions.ApiType.POST,
                Data = cartDto,
                Url = StaticDefinitions.ShoppingCartAPIBase + "/api/cart/UpdateCart",
                AccessToken = token
            });
        }


    }
}
