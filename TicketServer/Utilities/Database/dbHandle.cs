using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketServer.Utilities.Database
{
    internal class dbHandle
    {
        // singleton
        private static dbHandle instance;
        public static dbHandle Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new dbHandle();
                }
                return instance;
            }
        }
    }
}
