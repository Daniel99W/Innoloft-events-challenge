using EventsAPI.Core.Entities;
using EventsAPI.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.DAL
{
    public abstract class Repository<T>: IRepository<T> where T : BaseEntity

    {
        protected EventsDbContext _eventsDbContext { get; set; }

        public Repository(EventsDbContext eventsDbContext)
        {
            _eventsDbContext = eventsDbContext;
        }
        public virtual T Create(T obj)
        {
            return _eventsDbContext.Add(obj).Entity;
        }

        public virtual void Delete(T obj)
        {
            _eventsDbContext.Remove(obj);
        }

        public virtual async Task<T?> Read(int id)
        {
            return await _eventsDbContext.FindAsync<T>(id);
        }

        public void SaveChanges()
        {
            _eventsDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _eventsDbContext.SaveChangesAsync();
        }

        public virtual T Update(T obj)
        {
            return _eventsDbContext.Update(obj).Entity;
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await _eventsDbContext.Set<T>().ToListAsync();
        }

    }
}
