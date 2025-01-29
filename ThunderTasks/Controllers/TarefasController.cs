using Business.Repositories;
using Models;

namespace ThunderTasks.Controllers
{
    public class TarefasController : BaseController<TarefaModel>
    {
        public TarefasController(IGenericRepository<TarefaModel> repository) : base(repository)
        {
        }
    }
}
