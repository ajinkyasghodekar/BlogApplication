using DataAccess.Models.DTO.Blog;
using BlogWeb.Models;
using BlogWeb.Services.IServices;
using DataAccess.Utilities;

namespace BlogWeb.Services
{
    public class BlogService : BaseService, IBlogService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string blogUrl;

        public BlogService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            blogUrl = configuration.GetValue<string>("ServiceUrls:BlogApi");

        }

        public Task<T> CreateAsync<T>(BlogCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = blogUrl + "/api/BlogController"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = blogUrl + "/api/BlogController/" + id
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = blogUrl + "/api/BlogController/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = blogUrl + "/api/BlogController/"
            });
        }

        public Task<T> UpdateAsync<T>(BlogUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = blogUrl + "/api/BlogController/" + dto.BlogId
            });
        }
    }
}

