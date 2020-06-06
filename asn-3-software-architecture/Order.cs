using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class Order
    {
        public Guid Id { get; }
        public List<MenuItem> Items { get; }
        public Table Table { get; }
        public string Status { get; set; }

        public Order(Table t)
        {
            Id = Guid.NewGuid();
            Items = new List<MenuItem>();
            Table = t;
            Status = "Creating Order";
        }
        public Order(Order aOrder)
        {
            Items = new List<MenuItem>(aOrder.Items);
            Status = "Creating Order";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            sb.AppendLine();
            sb.AppendLine("----- ORDER");
            foreach (MenuItem itm in Items)
            {
                sb.Append($"{i}. ");
                sb.AppendLine(itm.ToString());
                i++;
            }
            sb.AppendLine();
            sb.AppendLine($"Total: ${TotalCost().ToString()}");
            sb.AppendLine("-----");

            return sb.ToString();
        }

        public Double TotalCost()
        {
            // Initialise
            Double result = 0;

            // Loop through and add totals
            foreach (MenuItem itm in Items)
            {
                result += itm.Price;
            }

            return result;
        }
    }
}
