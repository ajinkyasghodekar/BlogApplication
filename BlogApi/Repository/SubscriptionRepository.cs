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
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        private readonly MyAppDb _db;
        public SubscriptionRepository(MyAppDb db) : base(db) 
        {
            _db = db;
        }

        public async Task<Subscription> UpdateAsync(Subscription entity)
        {
            _db.Subscriptions.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}