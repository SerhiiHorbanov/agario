
namespace Engine
{
    abstract class State
    {
        StateMachine stateMachine;

        public State(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public abstract void Update();
        public abstract void Render();
        public abstract void Input();
    }
}
