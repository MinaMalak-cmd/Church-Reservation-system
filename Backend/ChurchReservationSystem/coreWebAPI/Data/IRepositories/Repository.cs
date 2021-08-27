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
        //protected DbSet<T> DbSet;
        public Repository(ReservationContext reservationContext)
        {
            this.ReservationContext = reservationContext;
            //DbSet = reservationContext.Set<T>();
        }
        public async Task<List<T>> GetAll()
        {
            return await ReservationContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            var entity =await ReservationContext.Set<T>().FindAsync(id);
                return entity;            
        }
        public virtual async Task<T> Post(T entity)
        {
            ReservationContext.Set<T>().Add(entity);
             await ReservationContext.SaveChangesAsync();
             return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await ReservationContext.Set<T>().FindAsync(id);
            ReservationContext.Set<T>().Remove(entity);
                await ReservationContext.SaveChangesAsync();            
        }
        public async Task Update(T entity)
        {
             ReservationContext.Entry(entity).State = EntityState.Modified;
             await ReservationContext.SaveChangesAsync();

        }

       
    }
}
