using SFML.System;
using SFML.Graphics;
using Agario;
using Agario.Extensions;

namespace Agario.GameObjects.Render
{
    class AgarioSprite
    {
        public Sprite sprite = new Sprite();

        public Vector2f position = new Vector2f(0, 0);

        public bool toRender = true;

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

        public AgarioSprite(Vector2f position, Texture texture, bool toRender = true)
        {
            this.position = position;
            sprite.Texture = texture;
            this.toRender = toRender;
        }

        public AgarioSprite(AgarioSprite agarioSprite)
        {
            sprite = new Sprite(agarioSprite.sprite);
            position = agarioSprite.position;
            toRender = agarioSprite.toRender;
        }

        public AgarioSprite()
        {

        }

        public static AgarioSprite newSprite(Vector2f position, string path, bool toRender = true)
        {
            FileStream stream = new FileStream(path, FileMode.Open);

            AgarioSprite sprite = new AgarioSprite(position, new Texture(stream), toRender);

            stream.Close();

            return sprite;
        }

        public virtual void TryRender(Camera camera)
        {
            if (!toRender)
                return;

            if (isRendered(camera))
                Render(camera);
        }

        public bool isRendered(Camera camera)
            => new IntRect((Vector2i)position, new Vector2i(Width, Height)).Intersects((IntRect)camera.rectangle);

        public void Render(Camera camera)
        {
            SpritePosition = position - new Vector2f(Width * 0.5f, Height * 0.5f) - camera.center + new Vector2f(Camera.cameraSize.X * 0.5f, Camera.cameraSize.Y * 0.5f);
            AgarioGame.window.Draw(sprite);
        }
    }
}
