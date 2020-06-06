using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class StateKitchen : State
    {
        public StateKitchen() : base()
        {
        }
        public StateKitchen(Context aContext) : base(aContext)
        {
        }

        public override string Run(string command)
        {
            CommandProcessor cmd = CommandProcessor.GetInstance;
            return cmd.Execute(command, this);
        }

        public void SetupCmdProcessor()
        {
            // Set up CommandProcessor and Commands
            CommandProcessor cmd = CommandProcessor.GetInstance;
            cmd.Cleanup();

            // Create and register commands
            CommandView view = new CommandView();
            CommandCompleteOrder complete = new CommandCompleteOrder();

            // Base Commands
            CommandChangeState cState = new CommandChangeState();
            CommandSelectTable select = new CommandSelectTable();
            CommandExit exit = new CommandExit();
            CommandHelp help = new CommandHelp();

            // Register Commands
            cmd.Register(view);
            cmd.Register(complete);
            cmd.Register(cState);
            cmd.Register(select);
            cmd.Register(help);
            cmd.Register(exit);
        }
    }
}
