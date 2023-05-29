using BlogApplication.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Repository.IRepository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllAsync(Expression<Func<Blog, bool>> filter = null);
        Task<Blog> GetAsync(Expression<Func<Blog, bool>> filter = null, bool tracked = true);
        Task CreateAsync(Blog entity);
        
        Task RemoveAsync(Blog entity);

        Task SaveAsync();
    }
}
