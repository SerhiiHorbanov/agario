using SFML.System;
using SFML.Graphics;
using Agario.GameObjects.Interfaces;
using Agario.Extensions;
using Agario.GameObjects.Render;

namespace Agario.GameObjects
{
    abstract class CircleObject : GameObject, IRenderable
    {
        public Vector2f position { get; protected set; }
        public CircleShape shape { get; protected set; }

        public Camera camera;

        protected float radius;

        public void Render()
        {
            float clampedX = Math.Clamp(position.X, camera.rectangle.Left, camera.rectangle.Left + camera.rectangle.Width);
            float clampedY = Math.Clamp(position.Y, camera.rectangle.Top, camera.rectangle.Top + camera.rectangle.Height);

            float distanceToCamera = position.Distance(new Vector2f(clampedX, clampedY));

            if (distanceToCamera < radius)
                Draw();
        }

        virtual public void Draw()
        {
            shape.Radius = radius;
            shape.Position = position - camera.center - new Vector2f(radius, radius) + (new Vector2f(Camera.cameraSize.X, Camera.cameraSize.Y) * 0.5f);
            AgarioGame.window.Draw(shape);
        }
    }
}
