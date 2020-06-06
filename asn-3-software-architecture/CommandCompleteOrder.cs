using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandCompleteOrder : Command
    {
        public CommandCompleteOrder() : base("complete", "Completes a Kitchen Order moving it from the Kitchen to the FOH.")
        { }

        public override string Execute(string[] command, State state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            ServiceOrder service = ServiceOrder.GetInstance;
            int orderNo = Int32.Parse(command[1]);

            service.CompleteOrder(orderNo);
            
            sb.AppendLine("Order is complete and needs to be taken to the customer.");

            return sb.ToString();
        }
    }
}
