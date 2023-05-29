using BlogApi.Repository.IRepository;
using BlogApplication.DataAccess.Models;
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
    public class BlogRepository : IBlogRepository
    {
        private readonly MyAppDb _db;
        public BlogRepository(MyAppDb db)
        {
            _db = db;
        }
        public async Task CreateAsync(Blog entity)
        {
            await _db.BlogsTable.AddAsync(entity);
            await SaveAsync();
        }
        public async Task<Blog> GetAsync(Expression<Func<Blog, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Blog> query = _db.BlogsTable;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }
        public async Task<List<Blog>> GetAllAsync(Expression<Func<Blog, bool>> filter = null)
        {
            IQueryable<Blog> query = _db.BlogsTable;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }
        public async Task RemoveAsync(Blog entity)
        {
            _db.BlogsTable.Remove(entity);
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
    }
}
