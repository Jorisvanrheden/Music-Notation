using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Notation.Logic
{
    public class Measure
    {
        public List<Note> Notes
        {
            get { return notes; }
        }

        public MeasureTime MeasureTime
        {
            get { return measureTime; }
        }

        //Measure time (e.g. 4/4 or 3/4)
        private MeasureTime measureTime;

        private List<Note> notes = new List<Note>();
        //Collection of notes
      
        //Notes can be arranged per layer
        //I think you actually need only layers here
        //Then let the layers decide what to do
        //But first try without layers

        public Measure(MeasureTime measureTime)
        {
            this.measureTime = measureTime;
        }

        public void AddNote(Note note)
        {
            notes.Add(note);
        }
    }
}
