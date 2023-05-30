using SFML.System;
using SFML.Graphics;
using Agario.States;
using Agario.GameObjects;
using Agario.GameObjects.Interfaces;


namespace Agario
{
    static class Camera
    {
        public static Vector2f position;
        public static Vector2f cameraSize => (Vector2f)AgarioGame.window.Size;

        public static float Left
            => position.X - (cameraSize.X / 2);
        public static float Right
            => position.X + (cameraSize.X / 2);
        public static float Top
            => position.Y - (cameraSize.Y / 2);
        public static float Bottom
            => position.Y + (cameraSize.Y / 2);

        public static void Render(List<GameObject> gameObjects)
        {
            AgarioGame.window.Clear(Color.Black);

            foreach (GameObject gameObject in gameObjects)
                if (gameObject is IRenderable renderable)
                    renderable.TryRender();

            AgarioGame.window.Display();
        }
    }
}
