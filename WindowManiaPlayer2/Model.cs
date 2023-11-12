using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowManiaPlayer.Model
{
    class NoteObject
    {
        public int Time { get; set; }
        public int LongNote { get; set; }
        public double LongScrollTime { get; set; }
        public int Position { get; set; }
        public double ScrollTime { get; set; }
    }

    class TimingObject
    {
        public int Time { get; set; }
        public bool IsBPM { get; set; }
        public double Value { get; set; }
        public double ScrollPosition { get; set; }
        public double ScrollSpeed { get; set; }
    }
}
