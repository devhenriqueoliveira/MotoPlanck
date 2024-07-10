using MotoPlanck.Domain.Primitives;
using MotoPlanck.Domain.Utils;

namespace MotoPlanck.Domain.Core.Entities
{
    public sealed class Motorcycle : Entity
    {
        #region Properties
        public string Model { get; private set; }
        public string Plate { get; private set; }
        public int Year { get; private set; }

        #endregion

        #region Constructors
        public Motorcycle(string model, string plate, int year)
        {
            Ensure.NotEmptyOrNull(model, "The model is required.", nameof(model));
            Ensure.NotEmptyOrNull(plate, "The plate is required.", nameof(plate));
            Ensure.GreaterThanZero(year, "The year is not equals a zero", nameof(year));

            Model = model;
            Plate = plate;
            Year = year;
        }

        public Motorcycle()
        {
            
        }
        #endregion
    }
}