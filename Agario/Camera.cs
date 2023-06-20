using SFML.System;
using SFML.Graphics;
using Agario.GameObjects;
using Agario.GameObjects.Interfaces;


namespace Agario
{
    class Camera
    {
        public FloatRect rectangle = new FloatRect();
        public Vector2f center;
        public static Vector2f cameraSize => (Vector2f)AgarioGame.window.Size;

        public void Render(List<GameObject> gameObjects)
        {
            rectangle.Left = center.X - cameraSize.X * 0.5f;
            rectangle.Top = center.Y - cameraSize.Y * 0.5f;
            rectangle.Width = cameraSize.X;
            rectangle.Height = cameraSize.Y;

            AgarioGame.window.Clear(Color.Black);

            foreach (GameObject gameObject in gameObjects)
                gameObject.TryRender();

            AgarioGame.window.Display();
        }
    }
}
