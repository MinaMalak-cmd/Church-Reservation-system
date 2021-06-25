using coreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace coreWebAPI.Data.IRepositories
{
    public abstract class Repository<T> : IRepository<T> 
        where T:class
    {
        protected ReservationContext ReservationContext { get; set; }
        protected DbSet<T> DbSet;
        public Repository(ReservationContext reservationContext)
        {
            this.ReservationContext = reservationContext;
            DbSet = reservationContext.Set<T>();
        }
        public async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            var entity =await DbSet.FindAsync(id);
                return entity;            
        }
        public async Task<T> Post(T entity)
        {
             DbSet.Add(entity);
            await ReservationContext.SaveChangesAsync();
            return entity;
        }

        public async void Delete(int id)
        {
            var entity = await DbSet.FindAsync(id);
                DbSet.Remove(entity);
                await ReservationContext.SaveChangesAsync();            
        }
        public async void Update(T entity)
        {
            ReservationContext.Entry(entity).State = EntityState.Modified;
            await ReservationContext.SaveChangesAsync();
        }

       
    }
}
