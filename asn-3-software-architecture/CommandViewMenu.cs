using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandViewMenu : Command
    {
        public CommandViewMenu() : base("view menu", "Displays menu items and their relative index on the screen.")
        {

        }

        public override string Execute(string[] command, State state)
        {
            try
            {
                StateCustomer cust = (StateCustomer)state;
                Table lTable = cust.Context.Table;
                return lTable.Menu.ToString();
            } catch (Exception e)
            {
                return "Could not convert current state to Customer State.";
            }
        }
    }
}
