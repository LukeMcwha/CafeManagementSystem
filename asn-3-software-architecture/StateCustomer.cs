using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class StateCustomer : State
    {
        public StateCustomer() : base()
        {
        }
        public StateCustomer(Context c) : base(c)
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

            // Create and register Commands
            CommandView viewMenu = new CommandView();
            CommandAdd add = new CommandAdd();
            CommandRemove remove = new CommandRemove();
            CommandConfirm confirm = new CommandConfirm();

            // Base Commands
            CommandChangeState changeState = new CommandChangeState();
            CommandSelectTable select = new CommandSelectTable();
            CommandExit exit = new CommandExit();
            CommandHelp help = new CommandHelp();

            // Register commands
            cmd.Register(help);
            cmd.Register(viewMenu);
            cmd.Register(add);
            cmd.Register(remove);
            cmd.Register(confirm);
            cmd.Register(changeState);
            cmd.Register(select);
            cmd.Register(exit);
        }
    }
}
