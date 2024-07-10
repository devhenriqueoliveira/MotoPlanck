using MotoPlanck.Application.Abstractions.Common;

namespace MotoPlanck.Infrastructure.CrossCutting.Common
{
    /// <summary>
    /// Represents the current machine date and time.
    /// </summary>
    internal sealed class MachineDateTime : IDateTime
    {
        /// <inheritdoc />
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
