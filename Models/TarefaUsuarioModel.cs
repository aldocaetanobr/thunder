using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("tarefas_usuarios")]
    public class TarefaUsuarioModel : BaseDbModel
    {
        [Required]
        public Guid TarefaId { get; set; }

        [Required]
        public Guid UsuarioId { get; set; }

        public virtual TarefaModel Tarefa { get; set; } = null!;

        public virtual UsuarioModel Usuario { get; set; } = null!;
    }
}
