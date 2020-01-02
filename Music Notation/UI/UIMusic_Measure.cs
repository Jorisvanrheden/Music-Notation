using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Music_Notation.Logic;

namespace Music_Notation.UI
{
    public class UIMusic_Measure : UIControl
    {
        private Measure measure;

        private const int LINE_COUNT = 5;
        private const int Y_OFFSET = 15;
        private const int X_OFFSET = 0;
        private const float NOTE_ROTATION = 60;

        private Size NOTE_SIZE = new Size(8, 10);

        public UIMusic_Measure()
        {
            
        }

        public void LinkMeasure(Measure measure)
        {
            this.measure = measure;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, ClientRectangle);

            DrawBarLines(e.Graphics);
            DrawNotes(e.Graphics);
        }

        private void DrawBarLines(Graphics graphics)
        {
            int iterationHeight = GetIterationHeight();

            for (int i = 0; i < LINE_COUNT; i++)
            {
                int y = iterationHeight * i;

                Point A = new Point(0, Y_OFFSET + y);
                Point B = new Point(Width, Y_OFFSET + y);

                graphics.DrawLine(Pens.Black, A, B);
            }
        }

        private int GetIterationHeight()
        {
            int usableHeight = Height - (Y_OFFSET * 2);
            return usableHeight / (LINE_COUNT - 1);
        }

        private void DrawNotes(Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            if (measure != null)
            {
                List<Note> notes = measure.Notes;

                for (int i = 0; i < notes.Count; i++)
                {
                    int x = GetNodeX(i);
                    int y = GetNoteY(notes[i].NoteValue);

                    DrawNoteType(graphics, notes[i], new Point(x, y));
                }
            }           
        }

        private void DrawNoteType(Graphics graphics, Note note, Point location)
        {
            graphics.TranslateTransform(location.X, location.Y);
            graphics.RotateTransform(NOTE_ROTATION);

            Rectangle rectangle = new Rectangle(-NOTE_SIZE.Width / 2, -NOTE_SIZE.Height / 2, NOTE_SIZE.Width, NOTE_SIZE.Height);

            DrawNote(graphics, rectangle, (dynamic)note.NoteDuration);

            graphics.ResetTransform();
        }

        private void DrawNote(Graphics graphics, Rectangle rectangle, EighthNote note)
        {
            graphics.FillEllipse(Brushes.Black, rectangle);

            DrawNoteLine(graphics, rectangle);
        }

        private void DrawNote(Graphics graphics, Rectangle rectangle, QuarterNote note)
        {
            graphics.FillEllipse(Brushes.Black, rectangle);

            DrawNoteLine(graphics, rectangle);
        }

        private void DrawNote(Graphics graphics, Rectangle rectangle, HalfNote note)
        {
            graphics.DrawEllipse(new Pen(Brushes.Black, 2), rectangle);

            DrawNoteLine(graphics, rectangle);
        }

        private void DrawNote(Graphics graphics, Rectangle rectangle, WholeNote note)
        {
            graphics.DrawEllipse(new Pen(Brushes.Black, 2), rectangle);
        }

        private void DrawNoteLine(Graphics graphics, Rectangle rectangle)
        {
            const int LINE_HEIGHT = 16;
            const int LINE_OFFSET = 4;

            Point location = new Point((int)graphics.Transform.OffsetX, (int)graphics.Transform.OffsetY);

            Point lineStart = new Point(location.X + rectangle.X + rectangle.Width, location.Y + rectangle.Y + LINE_OFFSET);
            Point lineEnd = new Point(location.X + rectangle.X + rectangle.Width, location.Y + rectangle.Y - LINE_HEIGHT);

            if (location.Y < Height / 2)
            {
                lineStart = new Point(location.X + rectangle.X, location.Y + rectangle.Y + rectangle.Height - LINE_OFFSET);
                lineEnd = new Point(location.X + rectangle.X, location.Y + rectangle.Y + rectangle.Height + LINE_HEIGHT);
            }

            graphics.ResetTransform();
            graphics.DrawLine(Pens.Black, lineStart, lineEnd);
        }

        private int GetNodeX(int index)
        {
            int usableWidth = Width - X_OFFSET * 2;

            int quarterNotesTotal = measure.MeasureTime.TopTime;

            int widthPerSpace = usableWidth / quarterNotesTotal;


            float activeSpaceIndex = 0;

            for (int i = 0; i < index; i++)
            {
                activeSpaceIndex += measure.Notes[i].NoteDuration.ToQuarters();
            }

            return (int)(X_OFFSET + activeSpaceIndex * widthPerSpace + widthPerSpace / 2);
        }

        private int GetNoteY(Notes note)
        {
            int iterationHeight = GetIterationHeight();

            switch (note)
            {
                case Notes.F1:
                    return Y_OFFSET;
                case Notes.E1:
                    return (GetNoteY(Notes.F1) + GetNoteY(Notes.D)) / 2;
                case Notes.D:
                    return GetNoteY(Notes.F1) + iterationHeight;
                case Notes.C:
                    return (GetNoteY(Notes.D) + GetNoteY(Notes.B)) / 2;
                case Notes.B:
                    return GetNoteY(Notes.D) + iterationHeight;
                case Notes.A:
                    return (GetNoteY(Notes.B) + GetNoteY(Notes.G)) / 2;
                case Notes.G:
                    return GetNoteY(Notes.B) + iterationHeight;
                case Notes.F:
                    return (GetNoteY(Notes.G) + GetNoteY(Notes.E)) / 2;
                case Notes.E:
                    return GetNoteY(Notes.G) + iterationHeight;
            }

            return Y_OFFSET;
        }
    }
}
