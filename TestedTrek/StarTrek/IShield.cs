using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarTrek
{
    public class Shield
    {
        private bool raised = false;

        public bool IsUp
        {
            get { return raised; }
        }

        public bool IsBuckled()
        {
            return true;
        }

        public void RaiseShield(bool v)
        {
            raised = v;
        }
    }
}
