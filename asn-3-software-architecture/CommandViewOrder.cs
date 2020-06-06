using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandViewOrder : Command
    {
        public CommandViewOrder() : base("view order", "Displays the order.")
        { }

        public override string Execute(string[] command, State state)
        {
            try
            {
                StateCustomer cust = (StateCustomer)state;
                Table lTable = cust.Context.Table;
                return lTable.Order.ToString();
            }
            catch (Exception e)
            {
                return "Could not convert current state to Customer State.";
            }
        }
    }
}
