using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Music_Notation.UI
{
    public class UIButton : UIControl
    {
        public UIButton()
        {
            Brush idle = new SolidBrush(UIColors.DefaultGray1);
            Brush over = new SolidBrush(UIColors.CreateColor(UIColors.DefaultGray1, 1.1f));
            Brush down = new SolidBrush(UIColors.CreateColor(UIColors.DefaultGray1, 1.3f));

            SetBrushes(idle, over, down);
        }
    }
}
