using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("usuarios")]
    public class UsuarioModel : BaseDbModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public bool Ativo { get; set; } = false;

        public virtual ICollection<TarefaUsuarioModel> TarefasUsuarios { get; set; } = [];
    }
}
