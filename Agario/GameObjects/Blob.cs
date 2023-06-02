using SFML.System;
using SFML.Graphics;
using Agario.States;
using Agario.GameObjects.Interfaces;
using Agario.GameObjects.BlobControllers;
using Agario.Input;

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

        public Blob(Vector2f position, int mass, Color color, List<GameObject> gameObjects)//вибачте, я не знаю  як краще, АААААААААААААА
        {
            this.position = position;
            this.controller = new AIController(this);
            Mass = mass;
            shape = new CircleShape(Radius);
            shape.FillColor = color;
            this.gameObjects = gameObjects;
        }

        public Blob(Vector2f position, int mass, Color color, List<GameObject> gameObjects, PlayerInput input)
        {
            this.position = position;
            this.controller = new PlayerController(this, input);
            Mass = mass;
            shape = new CircleShape(Radius);
            shape.FillColor = color;
            this.gameObjects = gameObjects;
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

        public void TryEat(Food food)
        {
            if (position.DistanceTo(food.position) > radius - Food.radius)
                return;
            Mass++;
            shape.Radius = Radius;
            food.ToDestroy = true;
        }

        public void TryEat(Blob blob)
        {
            if (blob == this)
                return;

            if (blob.mass > mass * 0.95)
                return;

            if (position.DistanceTo(blob.position) > radius - blob.radius)
                return;

            Mass += blob.mass;
            shape.Radius = radius;
            blob.ToDestroy = true;
        }

        public void RandomTeleport()
        {
            position = Playing.GetRandomPointInsideMap();
        }

        public void Update()
        {
            controller.ControlBlob();
        }
    }
}
