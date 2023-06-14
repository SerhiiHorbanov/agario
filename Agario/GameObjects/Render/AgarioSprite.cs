using SFML.System;
using SFML.Graphics;
using Agario;
using Agario.Extensions;

namespace Agario.GameObjects.Render
{
    class AgarioSprite
    {
        Sprite sprite = new Sprite();

        public Vector2f position = new Vector2f(0, 0);

        public Vector2f SpritePosition
        {
            get
                => sprite.Position;

            set
                => sprite.Position = value;
        }

        public int Width
            => (int)sprite.Texture.Size.X;
        
        public int Height
            => (int)sprite.Texture.Size.Y;

        public AgarioSprite(Vector2f position, Texture texture)
        {
            this.position = position;
            sprite.Texture = texture;
        }

        public static AgarioSprite newSprite(Vector2f position, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open);

            AgarioSprite sprite = new AgarioSprite(position, new Texture(stream));

            stream.Close();

            return sprite;
        }

        public void TryRender(Camera camera)
        {
            SpritePosition = position - camera.center + new Vector2f(Camera.cameraSize.X * 0.5f, Camera.cameraSize.Y * 0.5f);
            if (isRendered(camera))
                Render(camera);
        }

        public bool isRendered(Camera camera)
            => new IntRect((Vector2i)position, new Vector2i(Width, Height)).Intersects((IntRect)camera.rectangle);

        public void Render(Camera camera)
        {
            AgarioGame.window.Draw(sprite);
        }
    }
}
