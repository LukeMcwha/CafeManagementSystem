using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandAddItem : Command
    {
        public CommandAddItem() : base("add item", "Adds item to the Order.")
        { }

        public override string Execute(string[] command, State aState)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            
            try
            {
                // Local Variables
                Table lTable = aState.Context.Table;
                if(lTable.Reservation != null)
                {
                    Order lOrder = lTable.Order;

                    if (lOrder.Status == "Creating Order")
                    {
                        // Adds item from menu to order
                        MenuItem item = lTable.Menu.Items[Int32.Parse(command[2])];
                        lOrder.Items.Add(item);

                        sb.AppendLine($"Order Item {command[2]}: {item.Name} has been added to the order.").ToString();
                    }
                    else
                    {
                        sb.AppendLine("Order has already been confirmed and moved to the Kitchen.");
                    }
                }
                else
                {
                    sb.AppendLine("Table has no assigned reservation, therefore items cannot be added to the order.");
                }

                return sb.ToString();
            } catch (Exception e)
            {
                return sb.AppendLine("Invalid Command Input.").ToString();
            }
            
        }
    }
}
