namespace MotoPlanck.Application.Core.Motorcycles.Contracts
{
    /// <summary>
    /// Represents the delete motorcycle request.
    /// </summary>
    public sealed class DeleteMotorcycleRequest(Guid id)
    {
        /// <summary>
        /// Gets or sets the motorcycle identificator.
        /// </summary>
        public Guid Id { get; private set; } = id;
    }
}
