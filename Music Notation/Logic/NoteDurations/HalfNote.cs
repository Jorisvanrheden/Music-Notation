using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Notation.Logic
{
    public class HalfNote : NoteDuration
    {
        public HalfNote()
        {
                
        }

        public override float ToQuarters()
        {
            return 2;
        }
    }
}
