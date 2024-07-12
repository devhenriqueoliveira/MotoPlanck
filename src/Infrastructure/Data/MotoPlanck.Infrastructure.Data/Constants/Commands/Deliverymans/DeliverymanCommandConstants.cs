namespace MotoPlanck.Infrastructure.Data.Constants.Commands.Deliverymans
{
    /// <summary>
    /// Represents the commands sql of deliverymans
    /// </summary>
    internal static class DeliverymanCommandConstants
    {
        internal const string CREATE_DELIVERYMAN = "INSERT INTO Deliverymans (Id, Cnpj, Cnh, TypeCnh, PictureCnhId, UserId) VALUES (@Id, @Cnpj, @Cnh, @TypeCnh, @PictureCnhId, @UserId);";
        internal const string UPDATE_DELIVERYMAN = "UPDATE Deliverymans SET Cnpj = @Cnpj, Cnh = @Cnh, TypeCnh = @TypeCnh, PictureCnhId = @PictureCnhId, UserId = @UserId WHERE Id = @Id;";
        internal const string DELETE_DELIVERYMAN = "DELETE FROM Deliverymans WHERE Id = @Id;";
    }
}
