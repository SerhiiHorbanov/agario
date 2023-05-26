using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Game
    {
        public StateMachine stateMachine;

        public bool continuePlaying = true;

        public Game()
        {
            stateMachine = new StateMachine();
        }

        public void Run()
        {
            while (continuePlaying)
            {
                stateMachine.Update();
                stateMachine.Render();
                stateMachine.Input();
                stateMachine.Timing();
            }
        }
    }
}
