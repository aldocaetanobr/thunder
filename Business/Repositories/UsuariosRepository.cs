using Business.Dto;
using Business.Hubs;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace Business.Repositories
{
    public class UsuariosRepository : GenericRepository<UsuarioModel>, IGenericRepository<UsuarioModel>
    {
        public UsuariosRepository(DataContext context, IHubContext<NotificationHub> hubContext) : base(context, hubContext)
        {
        }
    }
}
