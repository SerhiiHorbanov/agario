using SFML.System;
using SFML.Graphics;
using Agario.States;

namespace Agario
{
    class Player
    {
        public Vector2f position;
        public Color color;
        public CircleShape shape;

        private float mass;
        private float radius;

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
                mass = (float)Math.PI * value * value;
                radius = value; 
            }
        }

        public Player(Vector2f position, int mass, Color color)
        {
            this.position = position;
            this.mass = mass;
            this.color = color;
            shape = new CircleShape(Radius);
        }

        public void Move(Vector2f move)
        {
            position += move;
        }

        public void Eat()
        {
            mass++;
            shape.Radius = Radius;
        }
    }
}
