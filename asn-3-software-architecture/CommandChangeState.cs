using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandChangeState : Command
    {
        public CommandChangeState() : base("state", "This command will transition the users perspective from one view to another. eg Move from Customer State to Kitchen State.")
        { }

        public override string Execute(string[] command, State state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            if (command.Length != 2)
            {
                sb.AppendLine("This command requires state ( state <customer | kitchen | foh> )");
            } 
            else
            {
                StateFactory factory = StateFactory.GetInstance;
                switch(command[1].ToLower())
                {
                    case "kitchen":
                        state.Context.ChangeState(factory.GetState("kitchen"));
                        sb.AppendLine("State Change to Kitchen.");
                        break;
                    case "foh":
                        state.Context.ChangeState(factory.GetState("foh"));
                        sb.AppendLine("State Change to Front Of House.");
                        break;
                    default:
                        state.Context.ChangeState(factory.GetState("customer"));
                        sb.AppendLine("State Change to Customer.");
                        break;
                }
            }

            return sb.ToString();
        }
    }
}
