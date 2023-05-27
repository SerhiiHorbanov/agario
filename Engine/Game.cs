namespace Engine
{
    public abstract class Game
    {
        public StateMachine stateMachine;

        public bool continuePlaying = true;

        public Game()
        {
            stateMachine = new StateMachine();
        }

        public void Run()
        {
            SetStartingState();
            while (continuePlaying)
            {
                stateMachine.Update();
                stateMachine.Render();
                stateMachine.Input();
                stateMachine.Timing();
            }
        }

        protected abstract void SetStartingState();
    }
}
