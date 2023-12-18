using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Classes
{
    public class Payments
    {
        public List<int> OrderIdList { get; set; }

        public Payments(List<int> orderIdList)
        {
            this.OrderIdList = orderIdList;
        }
    }
}
