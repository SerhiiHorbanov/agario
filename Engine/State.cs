using System;

namespace Engine
{
    public abstract class State
    {
        private long ticksBetweenFrames = TimeSpan.TicksPerSecond / 60;

        public long lastTimingTick = DateTime.Now.Ticks;

        public long neededFPS
        {
            get
               => TimeSpan.TicksPerSecond / ticksBetweenFrames;
            set
               => ticksBetweenFrames = TimeSpan.TicksPerSecond / neededFPS;
        }

        public virtual void Initialize()
        {

        }
        public abstract void Update();
        public abstract void Render();
        public abstract void Input();
        public void Timing()
        {
            if (DateTime.Now.Ticks - lastTimingTick < ticksBetweenFrames)
            {
                int timeToSleep = (int)((ticksBetweenFrames - (DateTime.Now.Ticks - lastTimingTick)) / TimeSpan.TicksPerMillisecond);
                System.Threading.Thread.Sleep(timeToSleep);
            }
            lastTimingTick = DateTime.Now.Ticks;
        }
    }
}
