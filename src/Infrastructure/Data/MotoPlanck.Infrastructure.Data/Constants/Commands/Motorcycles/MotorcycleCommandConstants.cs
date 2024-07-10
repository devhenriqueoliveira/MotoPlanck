namespace MotoPlanck.Infrastructure.Data.Constants.Commands.Motorcycles
{
    public static class MotorcycleCommandConstants
    {
        public const string CREATE_MOTORCYCLE = "INSERT INTO Motorcycle (Id, Year, Plate, Model) VALUES (@Id, @Year, @Plate, @Model)";
        public const string UPDATE_MOTORCYCLE = "UPDATE Motorcycle SET Plate = @Plate WHERE Id = @Id";
        public const string UPDATE_PLATE_BY_ID_MOTORCYCLE = "UPDATE Motorcycle SET Plate = @Plate WHERE Id = @Id";
        public const string DELETE_MOTORCYCLE = "DELETE FROM Motorcycle WHERE Id = @Id";
    }
}
