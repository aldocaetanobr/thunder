using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Business.Dto
{
    public static class EdmModels
    {
        public static IEdmModel Build()
        {
            var builder = new ODataConventionModelBuilder();
            EntitySet<TarefaModel>(builder);
            EntitySet<UsuarioModel>(builder);
            EntitySet<TarefaUsuarioModel>(builder);

            return builder.GetEdmModel();
        }

        private static void EntitySet<T>(this ODataConventionModelBuilder builder) where T : BaseDbModel
        {
            builder.EntitySet<T>(GetTableName(typeof(T)));
        }

        public static string GetTableName(Type type)
        {
            var tableAttribute = type.GetTypeInfo().GetCustomAttribute<TableAttribute>();

            if (tableAttribute == null || string.IsNullOrEmpty(tableAttribute?.Name))
            {
                throw new InvalidOperationException($"O atributo [Table] não está definido na classe {type}.");
            }

            return tableAttribute.Name;
        }
    }
}
