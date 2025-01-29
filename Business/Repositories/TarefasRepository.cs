using Business.Dto;
using Business.Hubs;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace Business.Repositories
{
    public class TarefasRepository : GenericRepository<TarefaModel>, IGenericRepository<TarefaModel>
    {
        public TarefasRepository(DataContext context, IHubContext<NotificationHub> hubContext) : base(context, hubContext)
        {
        }
    }
}
