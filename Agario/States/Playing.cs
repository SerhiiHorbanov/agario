using Engine;
using SFML.System;
using SFML.Graphics;
using Agario.GameObjects;

namespace Agario.States
{
    class Playing : State
    {
        public static Vector2f mapSize = new Vector2f(5000, 5000);
        public List<Blob> players = new List<Blob>();
        public List<Food> foods = new List<Food>();
        public Camera camera { get; private set; }

        List<GameObject> gameObjects = new List<GameObject>();

        public Playing(StateMachine stateMachine) : base(stateMachine)
        {
            this.stateMachine = stateMachine;
            camera = new Camera(new Vector2f(500, 500));

            //для тесту щоб було видно
            players.Add(newPlayer());

            players[0].position = new Vector2f(500, 500);
            players[0].Mass = 100;
        }

        public override void Update()
        {
            
        }

        public override void Render()
        {
            camera.Render(gameObjects);
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

        public Blob newPlayer()
        {
            Vector2f position = GetRandomPointInsideMap();
            byte[] colorBytes = new byte[3];
            AgarioGame.random.NextBytes(colorBytes);
            Color color = new Color(colorBytes[0], colorBytes[1], colorBytes[2]);
            return new Blob(position, 1, color);
        }

        public Food newFood()
        {
            Vector2f position = GetRandomPointInsideMap();
            byte[] colorBytes = new byte[3];
            AgarioGame.random.NextBytes(colorBytes);
            Color color = new Color(colorBytes[0], colorBytes[1], colorBytes[2]);
            return new Food(position, color);
        }
    }
}
