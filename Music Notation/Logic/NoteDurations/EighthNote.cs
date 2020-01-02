using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Notation.Logic
{
    public class EighthNote : NoteDuration
    {
        public EighthNote()
        {
                
        }

        public override float ToQuarters()
        {
            return 0.5f;
        }
    }
}
