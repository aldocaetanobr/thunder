using Business.Dto;
using Business.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;

namespace Business.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseDbModel
    {
        protected readonly DataContext _context;
        
        private readonly IHubContext<NotificationHub> _hubContext;

        public GenericRepository(DataContext context, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _hubContext = hubContext;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id)
                .ConfigureAwait(false);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow;
            entity.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.Set<T>().AddAsync(entity)
                .ConfigureAwait(false);

            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", EdmModels.GetTableName(typeof(T)), NotificationTypoEnum.Insert, entity);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var oldValue = await GetByIdAsync(entity.Id)
                .ConfigureAwait(false);

            entity.CreatedAt = oldValue?.CreatedAt ?? throw new Exception("O registro não existe.");

            entity.UpdatedAt = DateTimeOffset.UtcNow;

            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", EdmModels.GetTableName(typeof(T)), NotificationTypoEnum.Update, entity);

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id)
                .ConfigureAwait(false);

            if (entity == null)
            {
                throw new Exception("O registro não existe.");
            }

            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", EdmModels.GetTableName(typeof(T)), NotificationTypoEnum.Delete, entity);
        }
    }
}
