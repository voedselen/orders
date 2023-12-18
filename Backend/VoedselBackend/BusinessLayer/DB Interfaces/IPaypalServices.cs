using BusinessLayer.Classes;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DB_Interfaces
{
    public interface IPaypalServices
    {

        bool UpdatePaymentStatus(Payments orderList);
    }
}
