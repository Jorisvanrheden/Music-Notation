using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Music_Notation.Logic
{
    public static class SoundManager
    {
        public static void Play()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"C:\Users\Joris\Documents\Networking\Assets\Sounds\bomb.wav";

            player.Play();
        }
    }
}
