using SFML.System;
using SFML.Graphics;
using Agario.GameObjects.Interfaces;

namespace Agario.GameObjects
{
    abstract class CircleObject : GameObject, IRenderable
    {
        public Vector2f position;
        protected CircleShape shape = new CircleShape();

        protected float radius;

        public void TryRender()
        {
            float clampedX = Math.Clamp(position.X, Camera.Left, Camera.Right);
            float clampedY = Math.Clamp(position.Y, Camera.Top, Camera.Bottom);

            float differenceX = position.X - clampedX;
            float differenceY = position.Y - clampedY;

            float distanceToCamera = (float)Math.Sqrt((differenceX * differenceX) + (differenceY * differenceY));

            if (distanceToCamera < radius)
                Render();
        }

        void Render()
        {
            shape.Radius = radius;
            shape.Position = position - Camera.position - new Vector2f(radius, radius) + (new Vector2f(Camera.cameraSize.X, Camera.cameraSize.Y) * 0.5f);
            AgarioGame.window.Draw(shape);
        }
    }
}
