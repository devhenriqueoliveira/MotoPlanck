namespace MotoPlanck.Infrastructure.Data.Constants.Queries.Motorcycles
{
    public static class MotorcycleQueryConstants
    {
        public const string GET_ALL_MOTORCYCLE = "SELECT Id, Model, Plate FROM Motorcycle";
        public const string GET_BY_ID_MOTORCYCLE = "SELECT Id, Model, Plate FROM Motorcycle WHERE Id = @Id";
        public const string EXISTS_PLATE_MOTORCYCLE = "SELECT COUNT(1) FROM Motorcycle WHERE Plate = @Plate";
    }
}
