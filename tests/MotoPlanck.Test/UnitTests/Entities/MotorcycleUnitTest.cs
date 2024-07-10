using MotoPlanck.Domain.Core.Entities;

namespace MotoPlanck.Test.UnitTests.Entities
{
    public class MotorcycleUnitTest
    {
        [Fact]
        public void Motorcycle_ShouldCreateSuccessfully_WithValidParameters()
        {
            // Arrange
            string model = "Yamaha MT-07";
            string plate = "ABC1234";
            int year = 2020;

            // Act
            var motorcycle = new Motorcycle(model, plate, year);

            // Assert
            Assert.Equal(model, motorcycle.Model);
            Assert.Equal(plate, motorcycle.Plate);
            Assert.Equal(year, motorcycle.Year);
        }
    }
}
