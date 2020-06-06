using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class ServicePayment
    {
        private static ServicePayment _instance;

        private ServicePayment()
        { }

        public bool ProcessPayment(Order o)
        {
            // This method mimics an external payment system.
            return true;
        }

        public static ServicePayment GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServicePayment();
                }
                return _instance;
            }
        }
    }
}
