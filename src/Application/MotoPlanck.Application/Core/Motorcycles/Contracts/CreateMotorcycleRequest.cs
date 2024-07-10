namespace MotoPlanck.Application.Core.Motorcycles.Contracts
{
    public sealed class CreateMotorcycleRequest
    {
        /// <summary>
        /// Gets or sets the motorcycle year.
        /// </summary>
        public int Year { get; set; } = default!;

        /// <summary>
        /// Gets or sets the motorcycle model.
        /// </summary>
        public string Model { get; set; } = default!;

        /// <summary>
        /// Gets or sets the motorcycle plate.
        /// </summary>
        public string Plate { get; set; } = default!;
    }
}
