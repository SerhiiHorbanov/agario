using Engine;
using SFML.System;
using SFML.Graphics;
using Agario.GameObjects;
using Agario.GameObjects.Interfaces;

namespace Agario.States
{
    class Playing : State
    {
        public static Vector2f mapSize = new Vector2f(5000, 5000);

        List<GameObject> gameObjects = new List<GameObject>();

        public Playing(StateMachine stateMachine) : base(stateMachine)
        {
            this.stateMachine = stateMachine;

            //для тесту щоб було видно

            Camera.position = new Vector2f(250, 250);
            gameObjects.Add(newPlayer());

            if (gameObjects[0] is Blob)
            {
                Blob blob = gameObjects[0] as Blob;
                blob.position = new Vector2f(0, 0);
                blob.Mass = 100;
            }

            gameObjects.Add(newPlayer());

            if (gameObjects[1] is Blob)
            {
                Blob blob = gameObjects[1] as Blob;
                blob.position = new Vector2f(260, 250);
                blob.Mass = 1;
            }

            gameObjects.Add(newPlayer());

            if (gameObjects[2] is Blob)
            {
                Blob blob = gameObjects[2] as Blob;
                blob.position = new Vector2f(0, 250);
                blob.Mass = 10;
            }

            gameObjects.Add(newPlayer());

            if (gameObjects[3] is Blob)
            {
                Blob blob = gameObjects[3] as Blob;
                blob.position = new Vector2f(100, 100);
                blob.Mass = 50;
            }
        }

        public override void Update()
        {
            foreach (GameObject gameObject in gameObjects)
                if (gameObject is IUpdateable updateable)
                    updateable.Update();
        }

        public override void Render()
        {
            Camera.Render(gameObjects);
        }

        public override void Input()
        {
            AgarioGame.window.DispatchEvents();
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
