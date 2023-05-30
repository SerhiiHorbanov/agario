using SFML.System;
using SFML.Graphics;
using Agario.GameObjects.Interfaces;

namespace Agario.GameObjects
{
    abstract class CircleObject : GameObject, IRenderable
    {
        public Vector2f position;
        private CircleShape shape;

        private float radius;

        public void TryRender()
        {
            shape.Position = position;

            float clampedX = Math.Clamp(shape.Position.X, Left, Right);
            float clampedY = Math.Clamp(shape.Position.Y, Top, Bottom);

            float differenceX = shape.Position.X - clampedX;
            float differenceY = shape.Position.Y - clampedY;

            float distanceToCamera = (float)Math.Sqrt((differenceX * differenceX) + (differenceY * differenceY));

            if (distanceToCamera < shape.Radius)
                Render();
        }

        protected void Render()
        {
            shape.Position = position - position;
            AgarioGame.window.Draw(shape);
        }
    }
}
