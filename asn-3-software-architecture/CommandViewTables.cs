using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandViewTables : Command
    {
        public CommandViewTables() : base("view tables", "Views the state of all the tables in the Cafe.")
        { }
        public override string Execute(string[] command, State state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            foreach (KeyValuePair<string,Table> pair in state.Context.Tables)
            {
                sb.AppendLine(pair.Value.ToString());
            }

            return sb.ToString();
        }
    }
}
