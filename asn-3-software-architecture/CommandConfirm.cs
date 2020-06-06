using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandConfirm : Command
    {
        public CommandConfirm() : base("confirm", "Runs child process depending on the command.")
        { }

        public override string Execute(string[] command, State state)
        {
            try
            {
                switch (command[1])
                {
                    case "order":
                        CommandConfirmOrder confirmOrder = new CommandConfirmOrder();
                        return confirmOrder.Execute(command, state);
                }
            }
            catch (Exception e)
            {
                return "View Command was not executed correctly.";
            }

            return "Nothing Happened...";
        }
    }
}
