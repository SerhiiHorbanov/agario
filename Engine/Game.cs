using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Game
    {
        StateMachine stateMachine;

        bool continuePlaying = true;

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
