using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandViewExceeded : Command
    {
        public CommandViewExceeded() : base("view exceeded", "Views all exceeded orders.")
        { }
        public override string Execute(string[] command, State state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            StateFactory factory = StateFactory.GetInstance;
            StateFOH foh = (StateFOH)factory.GetState("foh");

            sb.AppendLine(foh.ExceededOrdersToString());

            return sb.ToString();
        }
    }
}
