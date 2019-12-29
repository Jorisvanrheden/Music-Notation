using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Music_Notation.UI
{
    public class UIControl : Control
    {
        private Brush BRUSH_ACTIVE;
        private Brush BRUSH_IDLE;
        private Brush BRUSH_MOUSE_OVER;
        private Brush BRUSH_MOUSE_DOWN;

        public UIControl()
        {
            DoubleBuffered = true;
        }

        protected void SetBrushes(Brush idle, Brush mouseOver, Brush mouseDown)
        {
            BRUSH_IDLE = idle;
            BRUSH_MOUSE_OVER = mouseOver;
            BRUSH_MOUSE_DOWN = mouseDown;

            BRUSH_ACTIVE = idle;

            MouseEnter  -= UIControl_MouseEnter;
            MouseLeave  -= UIControl_MouseLeave;
            MouseDown   -= UIControl_MouseDown;
            MouseUp     -= UIControl_MouseUp;

            MouseEnter  += UIControl_MouseEnter;
            MouseLeave  += UIControl_MouseLeave;
            MouseDown   += UIControl_MouseDown;
            MouseUp     += UIControl_MouseUp;
        }

        private void UIControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (ClientRectangle.Contains(e.Location))
            {
                BRUSH_ACTIVE = BRUSH_MOUSE_OVER;
            }
            else
            {
                BRUSH_ACTIVE = BRUSH_IDLE;
            }

            Invalidate();
        }

        private void UIControl_MouseDown(object sender, MouseEventArgs e)
        {
            BRUSH_ACTIVE = BRUSH_MOUSE_DOWN;
            Invalidate();
        }

        private void UIControl_MouseLeave(object sender, EventArgs e)
        {
            BRUSH_ACTIVE = BRUSH_IDLE;
            Invalidate();
        }

        private void UIControl_MouseEnter(object sender, EventArgs e)
        {
            BRUSH_ACTIVE = BRUSH_MOUSE_OVER;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (BRUSH_ACTIVE != null)
            {
                e.Graphics.FillRectangle(BRUSH_ACTIVE, ClientRectangle);
            }
        }
    }
}
