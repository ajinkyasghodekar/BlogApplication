using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Repository.IRepository
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<Blog> UpdateAsync(Blog entity);
    }
}