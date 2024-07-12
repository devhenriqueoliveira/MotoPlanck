using MotoPlanck.Domain.Core.Enums;
using MotoPlanck.Domain.Primitives;
using MotoPlanck.Domain.Utils;

namespace MotoPlanck.Domain.Core.Entities
{
    public sealed class Deliveryman : Entity
    {
        #region Constructors
        public Deliveryman(string cnpj, string cnh, ECnhType typeCnh, string pictureCnhId, User user)
        {
            Ensure.NotEmpty(cnpj, "The cnpj is required.", nameof(cnpj));
            Ensure.NotEmpty(cnh, "The cnpj is required.", nameof(cnh));
            Ensure.NotNull(typeCnh, "The type of cnh is required.", nameof(typeCnh));
            Ensure.NotEmpty(pictureCnhId, "The identificator of cnh picture is required.", nameof(pictureCnhId));
            Ensure.NotNull(user, "The user is not be null.", nameof(user));

            Cnpj = cnpj;
            Cnh = cnh;
            TypeCnh = typeCnh;
            PictureCnhId = pictureCnhId;
            User = user;
        }

        public Deliveryman(string cnpj, string cnh, ECnhType typeCnh, string pictureCnhId, Guid userId)
        {
            Ensure.NotEmpty(cnpj, "The cnpj is required.", nameof(cnpj));
            Ensure.NotEmpty(cnh, "The cnpj is required.", nameof(cnh));
            Ensure.NotNull(typeCnh, "The type of cnh is required.", nameof(typeCnh));
            Ensure.NotEmpty(pictureCnhId, "The identificator of cnh picture is required.", nameof(pictureCnhId));
            Ensure.NotNull(userId, "The user is not be null.", nameof(userId));

            Cnpj = cnpj;
            Cnh = cnh;
            TypeCnh = typeCnh;
            PictureCnhId = pictureCnhId;
            UserId = userId;
        }
        #endregion

        #region Properties
        public string Cnpj { get; private set; }
        public string Cnh { get; private set; }
        public ECnhType TypeCnh { get; private set; }
        public string PictureCnhId { get; private set; }
        public User User { get; private set; }
        #endregion

        #region Fields
        public Guid UserId { get; }
        #endregion
    }
}
