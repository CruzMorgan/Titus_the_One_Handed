using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titus_the_One_Handed
{
    public struct Animation
    {
        private float fps;
        public float FPS { get { return fps; } init { fps = 1.0000000000000f / value; } }
        public string Filename { get; init; }
        public int NumOfFrames { get; init; }
    }

}
