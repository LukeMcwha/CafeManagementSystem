using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class MenuItem
    {
        public string Name { get; set; }
        public List<MenuItem> Items { get; }
        public Double Price { get; }

        public MenuItem()
        {
            Items = new List<MenuItem>();
        }
        public MenuItem(string aName, Double aPrice, List<MenuItem> aItems)
        {
            Name = aName;
            Price = aPrice;
            Items = new List<MenuItem>(aItems);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Name} : $ {Price}");

            return sb.ToString();
        }
    }
}
