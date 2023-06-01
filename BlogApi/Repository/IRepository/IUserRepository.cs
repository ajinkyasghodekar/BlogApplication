using BlogApplication.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Repository.IRepository
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users> UpdateAsync(Users entity);
    }
}