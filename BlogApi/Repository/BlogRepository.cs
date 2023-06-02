using BlogApi.Repository.IRepository;
using DataAccess.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Repository.IRepository
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private readonly MyAppDb _db;
        public BlogRepository(MyAppDb db) : base(db) 
        {
            _db = db;
        }

        public async Task<Blog> UpdateAsync(Blog entity)
        {
            _db.BlogsTable.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}