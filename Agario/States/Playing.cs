using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using SFML.System;
using SFML.Graphics;

namespace Agario.States
{
    class Playing : State
    {
        public static Vector2f mapSize = new Vector2f(5000, 5000);
        public Playing(StateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void Update()
        {
            
        }

        public override void Render()
        {
            
        }

        public override void Input()
        {
            
        }

        public static Vector2f GetRandomPointInsideMap()
        {
            float x = (float)AgarioGame.random.NextDouble() * mapSize.X;
            float y = (float)AgarioGame.random.NextDouble() * mapSize.Y;
            return new Vector2f(x, y);
        }

        public static Player newPlayer()
        {
            Vector2f position = GetRandomPointInsideMap();
            byte[] colorBytes = new byte[3];
            AgarioGame.random.NextBytes(colorBytes);
            Color color = new Color(colorBytes[0], colorBytes[1], colorBytes[2]);
            return new Player(position, 1, color);
        }
    }
}
