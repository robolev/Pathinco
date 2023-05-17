using SFML.System;
using System.Diagnostics;

namespace Pathinco
{
    public  class Time
    {
        private Stopwatch stopwatch;

        public float DeltaTime { get; private set; }

        public Time()
        {
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            stopwatch.Start();
        }

        public void Update()
        {
            DeltaTime = (float)stopwatch.Elapsed.TotalSeconds;
            stopwatch.Restart();
        }
    }
}


