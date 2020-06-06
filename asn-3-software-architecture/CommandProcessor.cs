using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace asn_3_software_architecture
{
    
    public class CommandProcessor
    {
        private static CommandProcessor _instance;
        private Dictionary<string, Command> _commands { get; set; }

        private CommandProcessor()
        {
            _commands = new Dictionary<string, Command>();
        }

        public void Register(Command c)
        {
            _commands.Add(c.Name.ToLower(), c);
        }

        public void Unregister(Command c)
        {
            _commands.Remove(c.Name.ToLower());
        }



        public string Execute(string command, State state)
        {
            string[] split = command.Split(' ');
            try
            {
                return _commands[split[0]].Execute(split, state);
            } 
            catch (Exception e)
            {
                //Console.WriteLine(e.StackTrace);
                //Console.WriteLine(e.Message);
                return $"Cannot find command {split[0]}";
            }
            
        }

        public void Cleanup()
        {
            _commands = new Dictionary<string, Command>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("-------------------------");
            foreach (KeyValuePair<string, Command> cmd in _commands)
            {
                if (cmd.Key != "help")
                {
                    sb.AppendLine($"\t{cmd.Key} \t:: {cmd.Value.Description}");
                }
            }
            sb.AppendLine("-------------------------");

            return sb.ToString();
        }

        static public CommandProcessor GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommandProcessor();
                }
                return _instance;
            }
        }
    }
}
