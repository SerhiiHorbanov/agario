namespace Engine
{
    public abstract class Game
    {
        public State state;

        public bool continuePlaying = true;

        public void Run()
        {
            SetStartingState();
            while (continuePlaying)
            {
                state.Update();
                state.Render();
                state.Input();
                state.Timing();
            }
        }

        public void SetState(State state)
        {
            this.state = state;
            this.state.Initialize();
        }

        protected abstract void SetStartingState();
    }
}
