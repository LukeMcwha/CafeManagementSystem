using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandViewTable : Command
    {
        public CommandViewTable() : base("view table", "Views the currently selected table.")
        { }
        public override string Execute(string[] command, State aState)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            Table t = aState.Context.Table;
            sb.AppendLine(t.ToString());

            return sb.ToString();
        }
    }
}
