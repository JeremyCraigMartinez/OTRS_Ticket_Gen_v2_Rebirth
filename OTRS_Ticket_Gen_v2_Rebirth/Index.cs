using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTRS_Ticket_Gen_v2_Rebirth
{
    public class Index
    {
        #region Variables
        private int x;
        #endregion

        public Index() {x = 0;}
        public int Indexer { get { return x; } set { x = value; } }
        ~Index() 
        { 
        }
    }
}
