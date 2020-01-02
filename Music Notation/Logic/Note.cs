using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Notation.Logic
{
    public class Note
    {
        public Notes NoteValue
        {
            get { return note; }
        }
        public NoteDuration NoteDuration
        {
            get { return duration; }
        }

        private Notes note;
        private NoteDuration duration;

        public Note(Notes note, NoteDuration duration)
        {
            this.note = note;
            this.duration = duration;
        }
    }
}
