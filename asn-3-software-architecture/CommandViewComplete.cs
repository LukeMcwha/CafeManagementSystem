using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandViewComplete : Command
    {
        public CommandViewComplete() : base("view complete", "Views all completed orders.")
        { }
        public override string Execute(string[] command, State state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            StateFactory factory = StateFactory.GetInstance;
            StateFOH foh = (StateFOH)factory.GetState("foh");

            sb.AppendLine(foh.CompleteOrdersToString());

            return sb.ToString();
        }
    }
}
