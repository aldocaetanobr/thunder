using Business.Repositories;
using Models;

namespace ThunderTasks.Controllers
{
    public class UsuariosController : BaseController<UsuarioModel>
    {
        public UsuariosController(IGenericRepository<UsuarioModel> repository) : base(repository)
        {
        }
    }
}
