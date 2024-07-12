using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoPlanck.Infrastructure.Data.Constants.Queries.Deliverymans
{
    internal static class DeliverymanQueryConstants
    {
        internal const string GET_DELIVERYMANS = "";
        internal const string GET_DELIVERYMAN_BY_ID = "";
        internal const string EXISTS_CNH = "SELECT COUNT(1) FROM Deliverymans WHERE Cnh = @Cnh;";
        internal const string EXISTS_CNPJ = "SELECT COUNT(1) FROM Deliverymans WHERE Cnpj = @Cnpj;";
        internal const string EXISTS_DELIVERYMAN = "SELECT COUNT(1) FROM Deliverymans WHERE Id = @Id;";
    }
}
