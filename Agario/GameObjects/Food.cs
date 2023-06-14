using System;
using SFML.System;
using SFML.Graphics;

namespace Agario.GameObjects
{
    class Food : CircleObject
    {
        public new const float radius = 5;
        public Food(Vector2f position, Color color, Camera camera)
        {
            this.position = position;
            shape = new CircleShape(radius);
            shape.FillColor = color;
            shape.Position = position;
            base.radius = radius;
            this.camera = camera;
        }
    }
}
