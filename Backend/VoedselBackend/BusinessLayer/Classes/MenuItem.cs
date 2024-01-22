using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MenuItem
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public double price { get; private set; }

        public MenuItem(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }
}
