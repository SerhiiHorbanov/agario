using SFML.System;
using SFML.Graphics;
using Agario.States;
using Agario.GameObjects.Interfaces;
using Agario.GameObjects.BlobControllers;
using Agario.Input;
using Agario.Extensions;
using Agario.GameObjects.Render;

namespace Agario.GameObjects
{
    class Blob : CircleObject, IUpdateable
    {
        public BlobController controller;

        private float mass;

        public List<GameObject> gameObjects;

        public const float MoveSpeed = 50;

        public float Mass
        {
            get { return mass; }
            set
            {
                radius = (float)Math.Sqrt(value / Math.PI) * 10;
                mass = value;
            }
        }
        public float Radius
        {
            get { return radius; }
            set
            {
                mass = (float)Math.PI * value * value / 10;
                radius = value;
            }
        }

        public Blob(Vector2f position, int mass, Color color, List<GameObject> gameObjects, Camera camera)
        {
            this.position = position;
            this.controller = new AIController(this);
            Mass = mass;
            shape = new CircleShape(Radius);
            shape.FillColor = color;
            this.gameObjects = gameObjects;
            this.camera = camera;
        }

        public Blob(Vector2f position, int mass, Color color, List<GameObject> gameObjects, PlayerInput input, Camera camera)
        {
            this.position = position;
            this.controller = new PlayerController(this, input);
            Mass = mass;
            shape = new CircleShape(Radius);
            shape.FillColor = color;
            this.gameObjects = gameObjects;
            this.camera = camera;
        }

        public void Go(Vector2f Move)
        {
            float MoveLenght = (float)Math.Sqrt((Move.X * Move.X) + (Move.Y * Move.Y));
            if (MoveLenght > MoveSpeed / mass)
            {
                Move.X = Move.X / MoveLenght * MoveSpeed / mass;
                Move.Y = Move.Y / MoveLenght * MoveSpeed / mass;
            }
            position += Move;
        }

        private void CheckEating()
        {
            for (int j = 0; j < gameObjects.Count; j++)
            {
                GameObject gameObject = gameObjects[j];

                if (!gameObject.toDestroy)
                {
                    if (gameObject is Blob)
                        this.TryEat((Blob)gameObject);

                    if (gameObject is Food)
                        this.TryEat((Food)gameObject);
                }
            }
        }

        public void RandomTeleport()
        {
            position = Playing.GetRandomPointInsideMap();
            CreateTeleportationAnimation();
        }

        private void CreateTeleportationAnimation()
        {
            TeleportationEffect.teleportationAnimation.position = position;
            gameObjects.Add(new TeleportationEffect(new Animation(TeleportationEffect.teleportationAnimation), camera));
        }

        public void Update()
        {
            CheckEating();

            controller.ControlBlob();
        }
    }
}
