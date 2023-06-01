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
    public class UserRepository : Repository<Users>, IUserRepository
    {
        private readonly MyAppDb _db;
        public UserRepository(MyAppDb db) : base(db) 
        {
            _db = db;
        }

        public async Task<Users> UpdateAsync(Users entity)
        {
            _db.UsersTable.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}