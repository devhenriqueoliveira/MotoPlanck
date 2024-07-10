using MotoPlanck.Domain.Core.Enums;
using MotoPlanck.Domain.Primitives;
using MotoPlanck.Domain.Utils;

namespace MotoPlanck.Domain.Core.Entities
{
    public sealed class Deliveryman : Entity
    {
        #region Constructors
        public Deliveryman(string cnpj, string cnh, ECnhType typeCnh, string pictureCnhId)
        {
            Ensure.NotEmpty(cnpj, "The cnpj is required.", nameof(cnpj));
            Ensure.NotEmpty(cnh, "The cnpj is required.", nameof(cnh));
            Ensure.NotNull(typeCnh, "The type of cnh is required.", nameof(typeCnh));
            Ensure.NotEmpty(pictureCnhId, "The identificator of cnh picture is required.", nameof(pictureCnhId));

            Cnpj = cnpj;
            Cnh = cnh;
            TypeCnh = typeCnh;
            PictureCnhId = pictureCnhId;
        } 
        #endregion

        #region Properties
        public string Cnpj { get; private set; }
        public string Cnh { get; private set; }
        public ECnhType TypeCnh { get; private set; }
        public string PictureCnhId { get; private set; } 
        #endregion
    }
}
