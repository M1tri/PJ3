using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_LV3
{
    class VeganUnfriendly : Exception
    {
        public VeganUnfriendly(string message) : base(message) { }

    }
}
