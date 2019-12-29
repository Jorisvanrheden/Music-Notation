using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Music_Notation.UI
{
    public static class UIColors
    {
        private const int MAX_COLOR_VALUE = 255;

        public static Color DefaultGray1 = Color.FromArgb(80, 80, 80);
        public static Color DefaultGray2 = Color.FromArgb(100, 100, 100);
        public static Color DefaultGray3 = Color.FromArgb(120, 120, 120);
        public static Color DefaultGray4 = Color.FromArgb(140, 140, 140);

        public static Color CreateColor(Color baseColor, float scale)
        {
            int r = (int)(baseColor.R * scale);
            int g = (int)(baseColor.G * scale);
            int b = (int)(baseColor.B * scale);

            return GetConstrainedColor(r, g, b);
        }

        private static Color GetConstrainedColor(int r, int g, int b)
        {
            if (r > MAX_COLOR_VALUE) r = MAX_COLOR_VALUE;
            if (g > MAX_COLOR_VALUE) g = MAX_COLOR_VALUE;
            if (b > MAX_COLOR_VALUE) b = MAX_COLOR_VALUE;

            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;

            return Color.FromArgb(r, g, b);
        }
    }
}
