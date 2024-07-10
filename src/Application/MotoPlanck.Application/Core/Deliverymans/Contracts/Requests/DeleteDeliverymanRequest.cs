namespace MotoPlanck.Application.Core.Deliverymans.Contracts.Requests
{
    /// <summary>
    /// Represents the contract to delete a deliveryman.
    /// </summary>
    public sealed class DeleteDeliverymanRequest
    {
        // <summary>
        /// Gets or sets the deliveryman identificator.
        /// </summary>
        public Guid Id { get; set; }
    }
}
