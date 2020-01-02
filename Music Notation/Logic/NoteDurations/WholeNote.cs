using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Notation.Logic
{
    public class WholeNote : NoteDuration
    {
        public WholeNote()
        {
                
        }

        public override float ToQuarters()
        {
            return 4;
        }
    }
}
