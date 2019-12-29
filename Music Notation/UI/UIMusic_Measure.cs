using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Music_Notation.Logic;

namespace Music_Notation.UI
{
    public class UIMusic_Measure : UIControl
    {
        private List<Notes> notes;

        public UIMusic_Measure()
        {
            List<Notes> notes = new List<Notes>();
            notes.Add(Notes.A);
            notes.Add(Notes.B);
            notes.Add(Notes.C);

            SetNotes(notes);
        }

        private void SetNotes(List<Notes> notes)
        {
            this.notes = notes;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, ClientRectangle);

            DrawBarLines(e.Graphics);
            DrawNotes(e.Graphics);
        }

        private void DrawBarLines(Graphics graphics)
        {
            const int LINE_COUNT = 5;
            const int Y_OFFSET = 15;

            int usableHeight = Height - (Y_OFFSET * 2);
            int iterationHeight = usableHeight / (LINE_COUNT - 1);
            for (int i = 0; i < LINE_COUNT; i++)
            {
                int y = iterationHeight * i;

                Point A = new Point(0, Y_OFFSET + y);
                Point B = new Point(Width, Y_OFFSET + y);

                graphics.DrawLine(Pens.Black, A, B);
            }
        }

        private void DrawNotes(Graphics graphics)
        {

        }
    }
}
