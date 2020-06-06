using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    

    public abstract class State
    {
        public Context Context;

        public State()
        { Context = null; }
        public State(Context aContext)
        {
            Context = aContext;
        }

        public abstract string Run(string command);

        public void SetContext(Context aContext)
        {
            Context = aContext;
        }
    }
}
