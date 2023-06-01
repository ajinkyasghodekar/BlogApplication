using BlogApplication.DataAccess.Models.DTO.Blog;

namespace BlogWeb.Services.IServices
{
    public interface IBlogService
    {
        Task<T> GetAllAsync<T>();
        Task<T> CreateAsync<T>(BlogCreateDTO dto);
        Task<T> UpdateAsync<T>(BlogUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
