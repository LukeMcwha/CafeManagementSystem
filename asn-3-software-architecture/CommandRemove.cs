using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandRemove : Command
    {
        public CommandRemove() : base ("remove", "Removes specified item from a container. Syntax: remove < container > < index >")
        {

        }

        public override string Execute(string[] command, State state)
        {
            try
            {
                switch (command[1])
                {
                    case "item":
                        CommandRemoveItem removeItem = new CommandRemoveItem();
                        return removeItem.Execute(command, state);
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
