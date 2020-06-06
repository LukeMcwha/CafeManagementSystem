using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandAdd : Command
    {
        public CommandAdd() : base ("add", "Adds item to container. Syntax: add < item > < number >")
        { }

        public override string Execute(string[] command, State state)
        {
            try
            {
                switch (command[1])
                {
                    case "item":
                        CommandAddItem addItem = new CommandAddItem();
                        return addItem.Execute(command, state);
                    case "reservation":
                        CommandAddReservation addReservation = new CommandAddReservation();
                        return addReservation.Execute(command, state);
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
