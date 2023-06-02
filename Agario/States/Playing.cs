﻿using Engine;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Agario.GameObjects;
using Agario.GameObjects.Interfaces;
using Agario.Input;
using Agario.GameObjects.BlobControllers;

namespace Agario.States
{
    class Playing : State
    {
        public static Vector2f mapSize = new Vector2f(5000, 5000);

        PlayerInput input = new PlayerInput(
            new Dictionary<string, KeyBind> 
            {
                { "teleport", new KeyBind(Keyboard.Key.E)}
            },
            new Dictionary<string, Vector2f>
            {
                { "move", new Vector2f(0, 0) }
            });

        Blob playerBlob;

        List<GameObject> gameObjects = new List<GameObject>();
        public List<int> gameObjectsToDestroy = new List<int>();

        private int startPlayerCount = 100;
        private int foodCount = 500;

        public Playing(StateMachine stateMachine) : base(stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public override void Initialize()
        {
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
            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject is IUpdateable updateable)
                    updateable.Update();

                if (gameObject is Blob)
                {
                    UpdateBlob((Blob)gameObject);
                }
            }

            CheckGameObjectsToDestroy();
        }

        private void UpdateBlob(Blob blob)
        {
            for (int j = 0; j < gameObjects.Count; j++)
            {
                GameObject gameObject = gameObjects[j];

                if (!gameObject.ToDestroy)
                {
                    if (gameObject is Blob)
                        blob.TryEat((Blob)gameObject);

                    else if (gameObject is Food)
                        blob.TryEat((Food)gameObject);
                }
            }
        }

        private void CheckGameObjectsToDestroy()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject gameObject = gameObjects[i];
                if (gameObject.ToDestroy)
                {
                    gameObjects.RemoveAt(i);
                    i--;
                }
            }
        }

        public override void Render()
        {
            Camera.position = playerBlob.position;
            Camera.Render(gameObjects);
        }

        public override void Input()
        {
            AgarioGame.window.DispatchEvents();


            input.SetVector("move", (Vector2f)(Mouse.GetPosition(AgarioGame.window) - (Vector2i)(AgarioGame.window.Size / 2)));

            input.SetKeyPress("teleport", Keyboard.IsKeyPressed(input.GetKey("teleport")));
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
                return new Blob(position, 5, color, gameObjects);
            return new Blob(position, 5, color, gameObjects, input);
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
