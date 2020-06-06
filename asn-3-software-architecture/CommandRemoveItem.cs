using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandRemoveItem : Command
    {
        public CommandRemoveItem() : base("remove item", "Removes item from order list.")
        { }

        public override string Execute(string[] command, State state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            try
            {
                StateCustomer cust = (StateCustomer)state;

                // Local Variables
                Order lOrder = cust.Context.Table.Order;

                // Adds item from menu to order
                lOrder.Items.RemoveAt(Int32.Parse(command[2]) - 1);

                return sb.AppendLine($"Order Item {command[2]} has been removed from the order.").ToString();
            }
            catch (Exception e)
            {
                return sb.AppendLine("Invalid Command Input.").ToString();
            }
        }
    }
}
