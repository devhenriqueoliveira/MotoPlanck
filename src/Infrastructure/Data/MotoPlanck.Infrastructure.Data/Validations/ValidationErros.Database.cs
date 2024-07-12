using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.Infrastructure.Data.Validations
{
    internal static partial class ValidationErros
    {
        internal static class Database {   
            public static Error CreatedWithError => new("Database.CreatedWithError", "Object was not created");
            public static Error UpdatedWithError => new("Database.UpdatedWithError", "Object was not updated");
            public static Error DeletedWithError => new("Database.DeletedWithError", "Object was not deleted");
            public static Error SelectedWithError => new("Database.SelectedWithError", "Object was not selected");
        }
    }
}
