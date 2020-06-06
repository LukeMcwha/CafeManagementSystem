using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public abstract class AbstractEventSubscriber
    {
        public string EventName { get; }

        public AbstractEventSubscriber(string name)
        { EventName = name; }
        public abstract void Execute(Order o);
    }
}
