using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandViewOrders : Command
    {
        public CommandViewOrders() : base("view orders", "Displays all orders present in the Kitchen.")
        {

        }

        public override string Execute(string[] command, State state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            ServiceOrder service = ServiceOrder.GetInstance;

            sb.AppendLine(service.ToString());

            return sb.ToString();
        }
    }
}
