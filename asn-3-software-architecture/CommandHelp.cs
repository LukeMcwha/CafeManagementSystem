using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandHelp : Command
    {
        public CommandHelp() : base("help", "Welcome to the help pannel, see below the commands available in this state.")
        { }

        public override string Execute(string[] command, State state)
        {
            CommandProcessor cmd = CommandProcessor.GetInstance;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Description);
            sb.AppendLine();
            sb.AppendLine(cmd.ToString());

            return sb.ToString();
        }
    }
}
