using SFML.System;
using SFML.Graphics;
using Agario.States;

namespace Agario
{
    class Camera
    {
        Vector2f position;
        public Vector2f cameraSize => (Vector2f)AgarioGame.window.Size;
        private Playing state;

        public float Left
            => position.X - (cameraSize.X / 2);
        public float Right
            => position.X + (cameraSize.X / 2);
        public float Top
            => position.Y - (cameraSize.Y / 2);
        public float Bottom
            => position.Y + (cameraSize.Y / 2);

        public Camera(Vector2f position, Playing state)
        {
            this.position = position;
            this.state = state;
        }

        public void Render()
        {
            List<Player> playersToRender = new List<Player>();

            
        }

        public void RenderCircle(CircleShape shape, Vector2f positionOnMap)
        {
            shape.Position = position - position;

            float clampedX = Math.Clamp(shape.Position.X, Left, Right);
            float clampedY = Math.Clamp(shape.Position.Y, Top, Bottom);
            float differenceX = shape.Position.X - clampedX;
            float differenceY = shape.Position.Y - clampedY;
            float distanceToCamera = (float)Math.Sqrt((differenceX * differenceX) + (differenceY * differenceY));
            if (distanceToCamera < shape.Radius)
            {
                AgarioGame.window.Draw(shape);
            }
        }
    }
}
