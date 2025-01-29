using Business.Dto;
using Business.Hubs;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace Business.Repositories
{
    public class TarefasUsuariosRepository : GenericRepository<TarefaUsuarioModel>, IGenericRepository<TarefaUsuarioModel>
    {
        public TarefasUsuariosRepository(DataContext context, IHubContext<NotificationHub> hubContext) : base(context, hubContext)
        {
        }
    }
}
