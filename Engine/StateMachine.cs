using System;

namespace Engine
{
    public class StateMachine
    {
        private long ticksBetweenFrames = 0;
        public long lastTimingTick = 0;

        State state;

        public long neededFPS
        {
            get
               => TimeSpan.TicksPerSecond / ticksBetweenFrames;
            set
               => ticksBetweenFrames = TimeSpan.TicksPerSecond / neededFPS;
        }

        public void SetState(State state)
        {
            this.state = state;
        }

        public void Update()
        {
            state.Update();
        }

        public void Render()
        {
            state.Render();
        }

        public void Input()
        {
            state.Input();
        }

        public void Timing()
        {
            if (DateTime.Now.Ticks - lastTimingTick < TimeSpan.TicksPerSecond / neededFPS)
            {
                System.Threading.Thread.Sleep((int)(ticksBetweenFrames - DateTime.Now.Ticks - lastTimingTick));
            }
            lastTimingTick = DateTime.Now.Ticks;
        }
    }
}
