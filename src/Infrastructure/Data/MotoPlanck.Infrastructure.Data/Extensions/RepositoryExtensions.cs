using MotoPlanck.Domain.Primitives;

namespace MotoPlanck.Infrastructure.Data.Extensions
{
    internal static class RepositoryExtensions
    {
        public static Error CreatedWithError => new ("Repository.CreatedWithError", "Object was not created");
        public static Error UpdatedWithError => new ("Repository.UpdatedWithError", "Object was not updated");
        public static Error DeletedWithError => new ("Repository.DeletedWithError", "Object was not deleted");
        public static Error SelectedWithError => new ("Repository.SelectedWithError", "Object was not selected");
    }
}
