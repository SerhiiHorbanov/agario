using SFML.System;
using SFML.Graphics;
using Agario.States;

namespace Agario
{
    class Player
    {
        public Vector2f position;
        public int mass;
        public Color color;
        public CircleShape shape;

        public float radius
            => (float)Math.Sqrt(mass / Math.PI);

        public Player(Vector2f position, int mass, Color color)
        {
            this.position = position;
            this.mass = mass;
            this.color = color;
            shape = new CircleShape(radius);
        }

        public void Move(Vector2f move)
        {
            position += move;
        }

        public void Eat()
        {
            mass++;
            shape.Radius = radius;
        }
    }
}
