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
        Blob playerBlob;

        public Playing(StateMachine stateMachine, int playerCount, int foodCount) : base(stateMachine)
        {
            this.stateMachine = stateMachine;

            CreateFoodAndPlayers(playerCount, foodCount);

            if (playerCount <= 0)
                return;

            GameObject firstCreatedBlob = gameObjects[foodCount];

            if (firstCreatedBlob is Blob)
                playerBlob = (Blob)firstCreatedBlob;
        }

        public void CreateFoodAndPlayers(int playerCount, int foodCount)
        {
            for (int i = 0; i < foodCount; i++)
                gameObjects.Add(NewFood());

            if (playerCount <= 0)
                return;

            for (int i = 0; i < playerCount; i++)
                gameObjects.Add(NewPlayer());


        }

        public override void Update()
        {
            foreach (GameObject gameObject in gameObjects)
                if (gameObject is IUpdateable updateable)
                    updateable.Update();
        }

        public override void Render()
        {
            Camera.position = playerBlob.position;
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

        public Blob NewPlayer()
        {
            Vector2f position = GetRandomPointInsideMap();
            byte[] colorBytes = new byte[3];
            AgarioGame.random.NextBytes(colorBytes);
            Color color = new Color(colorBytes[0], colorBytes[1], colorBytes[2]);
            return new Blob(position, 1, color, true);
        }

        public Food NewFood()
        {
            Vector2f position = GetRandomPointInsideMap();
            byte[] colorBytes = new byte[3];
            AgarioGame.random.NextBytes(colorBytes);
            Color color = new Color(colorBytes[0], colorBytes[1], colorBytes[2]);
            return new Food(position, color);
        }
    }
}
