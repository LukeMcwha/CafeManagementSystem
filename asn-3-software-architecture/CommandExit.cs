using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandExit : Command
    {
        public CommandExit() : base("exit", "This command will exit the program.")
        { }

        public override string Execute(string[] command, State state)
        {
            return ToString();
        }

        public override string ToString()
        {
            return "Exit";
        }
    }
}
