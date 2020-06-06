using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandSelectTable : Command
    {
        public CommandSelectTable() : base("select", "Select a table that you wish to take the view of.")
        { }

        public override string Execute(string[] command, State aState)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            try
            {
                State state = aState;
                aState.Context.Table = aState.Context.Tables[command[1]];

                return sb.AppendLine($"Table {aState.Context.Table.Id} is now the table you are viewing.").ToString();
            }
            catch (Exception e)
            {
                return sb.AppendLine("Invalid Command Input.").ToString();
            }
        }
    }
}
