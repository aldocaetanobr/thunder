using Microsoft.EntityFrameworkCore;
using Models;

namespace Business.Dto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaUsuarioModel> TarefasUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BuildBasicTable<TarefaModel>(ref modelBuilder);
            BuildBasicTable<UsuarioModel>(ref modelBuilder);
            BuildBasicTable<TarefaUsuarioModel>(ref modelBuilder);

            // tarefas
            modelBuilder.Entity<TarefaModel>()
            .HasIndex(e => e.Titulo)
                .HasDatabaseName($"IX_{EdmModels.GetTableName(typeof(TarefaModel))}_titulo");

            modelBuilder.Entity<TarefaModel>()
            .HasIndex(e => e.Titulo)
                .HasDatabaseName($"IX_{EdmModels.GetTableName(typeof(TarefaModel))}_titulo");

            modelBuilder.Entity<TarefaModel>()
            .HasIndex(e => e.Inicio)
                .HasDatabaseName($"IX_{EdmModels.GetTableName(typeof(TarefaModel))}_inicio");

            modelBuilder.Entity<TarefaModel>()
            .HasIndex(e => e.Status)
                .HasDatabaseName($"IX_{EdmModels.GetTableName(typeof(TarefaModel))}_status");

            modelBuilder.Entity<TarefaModel>()
            .HasIndex(e => e.Conclusao)
                .HasDatabaseName($"IX_{EdmModels.GetTableName(typeof(TarefaModel))}_conclusao");

            modelBuilder.Entity<TarefaModel>()
            .HasIndex(e => e.Vencimento)
                .HasDatabaseName($"IX_{EdmModels.GetTableName(typeof(TarefaModel))}_vencimento");

            // usuarios
            modelBuilder.Entity<UsuarioModel>()
            .HasIndex(e => e.Ativo)
                .HasDatabaseName($"IX_{EdmModels.GetTableName(typeof(UsuarioModel))}_ativo");

            modelBuilder.Entity<UsuarioModel>()
            .HasIndex(e => e.Name)
                .HasDatabaseName($"IX_{EdmModels.GetTableName(typeof(UsuarioModel))}_name");

            // tarefas x usuarios
            modelBuilder.Entity<TarefaUsuarioModel>()
                .HasOne(tu => tu.Tarefa)
                .WithMany(t => t.TarefasUsuarios)
                .HasForeignKey(tu => tu.TarefaId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<TarefaUsuarioModel>()
                .HasOne(tu => tu.Usuario)
                .WithMany(u => u.TarefasUsuarios)
                .HasForeignKey(tu => tu.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void BuildBasicTable<T>(ref ModelBuilder modelBuilder) where T : BaseDbModel
        {
            var tableName = EdmModels.GetTableName(typeof(T));

            Console.WriteLine($"Verificando a tabela {tableName}");

            modelBuilder.Entity<T>().ToTable(tableName);

            modelBuilder.Entity<T>()
                .HasIndex(e => e.CreatedAt)
                .HasDatabaseName($"IX_{tableName}_CreatedAt");

            modelBuilder.Entity<T>()
                .HasIndex(e => e.UpdatedAt)
                .HasDatabaseName($"IX_{tableName}_UpdatedAt");
        }
    }
}
