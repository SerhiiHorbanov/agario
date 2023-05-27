namespace Engine
{
    public abstract class State
    {
        protected StateMachine stateMachine;

        public State(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public virtual void Initialize()
        {

        }
        public abstract void Update();
        public abstract void Render();
        public abstract void Input();
    }
}
