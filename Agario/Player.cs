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
        public Playing state;

        private int mass;
        private float radius;

        public int Mass 
        {
            get { return mass; }
            set 
            {
                radius = (float)Math.Sqrt(mass / Math.PI) * 10;
            }
        }
        public int Radius
        {
            get { return radius; }
            set 
            {
                
            }
        }

        public Player(Vector2f position, int mass, Color color, Playing state)
        {
            this.position = position;
            this.mass = mass;
            this.color = color;
            this.state = state;
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

        public void Render()
        {
            shape.Position = position;
            AgarioGame.window.Draw(shape);
        }
    }
}
