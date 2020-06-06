using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public abstract class Command
    {
        public string Name { get; }
        public string Description { get; }
        public Command(string aName, string aDescription)
        {
            Name = aName;
            Description = aDescription;
        }

        public abstract string Execute(string[] command, State state);
    }
}
