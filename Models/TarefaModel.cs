using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("tarefas")]
    public class TarefaModel : BaseDbModel
    {
        [Required]
        public string Titulo { get; set; } = null!;

        public string? Descricao { get; set; }

        [Required]
        public DateTimeOffset Inicio { get; set; }

        [Required]
        public DateTimeOffset Vencimento { get; set; }

        public DateTimeOffset? Conclusao { get; set; }

        [Required]
        public TarefaStatusEnum Status { get; set; } = TarefaStatusEnum.Pendente;

        public virtual ICollection<TarefaUsuarioModel> TarefasUsuarios { get; set; } = [];

    }
}
