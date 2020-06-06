using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandConfirmOrder : Command
    {
        public CommandConfirmOrder() : base("confirm order", "Confirms a table order moving it to the Kitchen.")
        { }

        public override string Execute(string[] command, State state)
        {
            StringBuilder sb = new StringBuilder();

            Order o = state.Context.Table.Order;
            o.Status = "Kitchen";
            ServiceOrder service = ServiceOrder.GetInstance;

            // Push order to the service...
            service.PushOrder(o);

            sb.AppendLine();
            sb.AppendLine("Your order has been confirmed and is being sent to the kitchen.");

            return sb.ToString();
        }
    }
}
