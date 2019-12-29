using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Notation.Logic
{
    public class MeasureTime
    {
        public int TopTime
        {
            get { return topTime; }
        }

        public int BottomTime
        {
            get { return bottomTime; }
        }

        private int topTime;
        private int bottomTime;

        public MeasureTime(int topTime, int bottomTime)
        {
            this.topTime = topTime;
            this.bottomTime = bottomTime;
        }
    }
}
