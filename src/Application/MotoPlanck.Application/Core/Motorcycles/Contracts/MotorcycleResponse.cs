namespace MotoPlanck.Application.Core.Motorcycles.Contracts
{
    /// <summary>
    /// Represents the motorcycle response.
    /// </summary>
    public sealed class MotorcycleResponse
    {
        /// <summary>
        /// Gets or sets the motorcycle identificator.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the motorcycle year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the motorcycle plate.
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// Gets or sets the motorcycle model.
        /// </summary>
        public string Model { get; set; }
    }
}
