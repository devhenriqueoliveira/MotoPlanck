namespace MotoPlanck.Infrastructure.Data.Constants.Queries.Motorcycles
{
    public static class MotorcycleQueryConstants
    {
        public const string GET_ALL_MOTORCYCLE = "SELECT Id, Model, Plate FROM Motorcycles";
        public const string GET_BY_ID_MOTORCYCLE = "SELECT Id, Model, Plate FROM Motorcycles WHERE Id = @Id";
        public const string GET_BY_PLATE_MOTORCYCLE = "SELECT Id, Model, Plate FROM Motorcycles WHERE Plate = @Plate";
        public const string EXISTS_PLATE_MOTORCYCLE = "SELECT COUNT(1) FROM Motorcycles WHERE Plate = @Plate";
    }
}
