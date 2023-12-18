using BusinessLayer.Classes;
using BusinessLayer.DB_Interfaces;
using PayPal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Logic
{
    public class PaypalService : IPaypalServices
    {
        readonly IDB_PaypalService db_paypalService;
        public PaypalService(IDB_PaypalService db_paypalService)
        {
            this.db_paypalService = db_paypalService;
        }

        public bool UpdatePaymentStatus(Payments payments)
        {
            try
            {
                db_paypalService.UpdatePaymentStatus(payments);
                return true;    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
