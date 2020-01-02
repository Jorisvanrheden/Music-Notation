using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Notation.Logic;

namespace Music_Notation.Source
{
    public class MainInterface
    {
        public Measure testMeasure;

        public MainInterface()
        {
            testMeasure = new Measure(new MeasureTime(8, 4));

            testMeasure.AddNote(new Note(Notes.A, new EighthNote()));
            testMeasure.AddNote(new Note(Notes.B, new EighthNote()));
            testMeasure.AddNote(new Note(Notes.C, new QuarterNote()));
            testMeasure.AddNote(new Note(Notes.B, new HalfNote()));
            testMeasure.AddNote(new Note(Notes.F1, new QuarterNote()));
            testMeasure.AddNote(new Note(Notes.F, new QuarterNote()));
            testMeasure.AddNote(new Note(Notes.E, new QuarterNote()));
        }
    }
}
