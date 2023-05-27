using Engine;
using SFML.System;
using SFML.Graphics;

namespace Agario.States
{
    class Playing : State
    {
        public static Vector2f mapSize = new Vector2f(5000, 5000);
        private List<Player> players = new List<Player>();
        private List<Food> foods = new List<Food>();
        public Camera camera { get; private set; }

        public Playing(StateMachine stateMachine) : base(stateMachine)
        {
            this.stateMachine = stateMachine;
            camera = new Camera();
        }

        public override void Update()
        {
            
        }

        public override void Render()
        {
            camera.Render();
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

        public Player newPlayer()
        {
            Vector2f position = GetRandomPointInsideMap();
            byte[] colorBytes = new byte[3];
            AgarioGame.random.NextBytes(colorBytes);
            Color color = new Color(colorBytes[0], colorBytes[1], colorBytes[2]);
            return new Player(position, 1, color, this);
        }

        public Food newFood()
        {
            Vector2f position = GetRandomPointInsideMap();
            byte[] colorBytes = new byte[3];
            AgarioGame.random.NextBytes(colorBytes);
            Color color = new Color(colorBytes[0], colorBytes[1], colorBytes[2]);
            return new Food(position, color, this);
        }
    }
}
