using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandViewStatistics : Command
    {
        public CommandViewStatistics() : base("view statistics", "View the statistics for the Cafe.")
        { }
        public override string Execute(string[] command, State state)
        {
            ServiceDB db = ServiceDB.GetInstance;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            sb.AppendLine(db.ToString());

            return sb.ToString();
        }
    }
}
