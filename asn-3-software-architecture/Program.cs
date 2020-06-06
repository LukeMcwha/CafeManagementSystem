using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            StateFactory factory = StateFactory.GetInstance;
            ServiceDB db = ServiceDB.GetInstance;

            context.ChangeState(factory.GetState("customer"));

            Console.WriteLine(context.Run(""));
        }
    }
}
