using BusinessLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DB_Interfaces
{
    public interface IDB_PaypalService
    {
        bool UpdatePaymentStatus(Payments orderlist);
    }
}
