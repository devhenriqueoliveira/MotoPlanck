namespace MotoPlanck.Application.Core.Motorcycles.Contracts
{
    public sealed class UpdatePlateMotorcycleRequest
    {
        /// <summary>
        /// Gets or sets the motorcycle plate.
        /// </summary>
        public string Plate { get; set; } = default!;
    }
}
