using Engine;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Agario.GameObjects;
using Agario.GameObjects.Interfaces;
using Agario.Input;
using Agario.GameObjects.BlobControllers;
using Agario.Extensions;

namespace Agario.States
{
    class Playing : State
    {
        public static Vector2f mapSize = new Vector2f(5000, 5000);

        Camera camera = new Camera();

        PlayerInput input = new PlayerInput();

        Blob playerBlob;

        List<GameObject> gameObjects = new List<GameObject>();
        public List<int> gameObjectsToDestroy = new List<int>();

        private int startPlayerCount = 100;
        private int foodCount = 500;

        public override void Initialize()
        {

            input.AddBinding("teleport", Keyboard.Key.E);
            input.AddVector2("move");

            for (int i = 0; i < foodCount; i++)
                gameObjects.Add(NewFood());

            if (startPlayerCount <= 0)
                return;

            playerBlob = NewPlayer(false);

            gameObjects.Add(playerBlob);

            for (int i = 1; i < startPlayerCount; i++)
                gameObjects.Add(NewPlayer(true));
        }

        public override void Update()
        {
            gameObjects.Update();

            gameObjects.CheckGameObjectsToDestroy();
        }

        

        public override void Render()
        {
            camera.center = playerBlob.position;
            camera.Render(gameObjects);
        }

        public override void Input()
        {
            AgarioGame.window.DispatchEvents();

            input.GetKeyInputInput();

            if (playerBlob.controller is PlayerController)
            {
                ((PlayerController)playerBlob.controller).CheckMoveInput();
            }
        }

        public static Vector2f GetRandomPointInsideMap()
        {
            float x = (float)AgarioGame.random.NextDouble() * mapSize.X;
            float y = (float)AgarioGame.random.NextDouble() * mapSize.Y;
            return new Vector2f(x, y);
        }

        public Blob NewPlayer(bool isAi)
        {
            Vector2f position = GetRandomPointInsideMap();

            byte[] colorBytes = new byte[3];
            AgarioGame.random.NextBytes(colorBytes);
            Color color = new Color(colorBytes[0], colorBytes[1], colorBytes[2]);

            if (isAi)
                return new Blob(position, 5, color, gameObjects, camera);
            return new Blob(position, 5, color, gameObjects, input, camera);
        }

        public Food NewFood()
        {
            Vector2f position = GetRandomPointInsideMap();
            byte[] colorBytes = new byte[3];
            AgarioGame.random.NextBytes(colorBytes);
            Color color = new Color(colorBytes[0], colorBytes[1], colorBytes[2]);
            return new Food(position, color, camera);
        }
    }
}
