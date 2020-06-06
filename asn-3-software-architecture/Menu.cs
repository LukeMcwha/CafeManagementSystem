using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class Menu
    {
        public List<MenuItem> Items { get; }
        public Menu()
        {
            Items = new List<MenuItem>();
        }
        public Menu(List<MenuItem> aItems)
        {
            Items = new List<MenuItem>(aItems);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            sb.AppendLine();
            foreach(MenuItem itm in Items)
            {
                sb.Append($"{i}. ");
                sb.AppendLine(itm.ToString());
                i++;
            }

            return sb.ToString();
        }
    }
}
