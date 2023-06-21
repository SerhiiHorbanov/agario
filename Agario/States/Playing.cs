using Engine;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Agario.GameObjects;
using Agario.GameObjects.Render;
using Agario.Input;
using Agario.GameObjects.BlobControllers;
using Agario.Extensions;

namespace Agario.States
{
    class Playing : State
    {
        public static Vector2f mapSize = new Vector2f(5000, 5000);

        PlayerInput input = new PlayerInput();

        public Scene scene = new Scene(new List<GameObject>(), new Camera());

        Blob playerBlob;

        private int startPlayerCount = 100;
        private int foodCount = 500;

        public override void Initialize()
        {

            input.AddBinding("teleport", Keyboard.Key.E);
            input.AddVector2("move");

            for (int i = 0; i < foodCount; i++)
                scene.Add(NewFood());

            if (startPlayerCount <= 0)
                return;

            playerBlob = NewPlayer(false);

            scene.Add(playerBlob);

            for (int i = 1; i < startPlayerCount; i++)
                scene.Add(NewPlayer(true));
        }

        public override void Update()
        {
            scene.Update();
        }

        

        public override void Render()
        {
            scene.camera.center = playerBlob.position;
            scene.Render();
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
                return new Blob(position, 5, color, scene.gameObjects, scene.camera);
            return new Blob(position, 5, color, scene.gameObjects, input, scene.camera);
        }

        public Food NewFood()
        {
            Vector2f position = GetRandomPointInsideMap();
            byte[] colorBytes = new byte[3];
            AgarioGame.random.NextBytes(colorBytes);
            Color color = new Color(colorBytes[0], colorBytes[1], colorBytes[2]);
            return new Food(new Animation(Food.standartAnimation), position, scene.camera);
        }
    }
}
