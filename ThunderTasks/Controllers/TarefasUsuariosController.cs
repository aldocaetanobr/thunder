using Business.Repositories;
using Models;

namespace ThunderTasks.Controllers
{
    public class TarefasUsuariosController : BaseController<TarefaUsuarioModel>
    {
        public TarefasUsuariosController(IGenericRepository<TarefaUsuarioModel> repository) : base(repository)
        {
        }
    }
}
