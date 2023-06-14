using SFML.System;
using SFML.Graphics;

namespace Agario.GameObjects.Render
{
    class Animation : AgarioSprite
    {
        Texture[] frames;

        public int frameToRender = 0;
        public bool paused = false;

        public Animation(Texture[] frames, Vector2f position, int frameToRender = 0, bool paused = false, bool toRender = true)
        {
            this.frames = frames;
            this.frameToRender = frameToRender;
            this.paused = paused;
            this.position = position;
            this.sprite = new Sprite(frames[frameToRender]);
            this.toRender = toRender;
        }

        public Animation(Animation animatedSprite)
        {
            frames = new Texture[animatedSprite.frames.Length];
            for (int i = 0; i < animatedSprite.frames.Length; i++)
            {
                frames[i] = new Texture(animatedSprite.frames[i]);
            }
            frameToRender = animatedSprite.frameToRender;
            paused = animatedSprite.paused;
            sprite = new Sprite(animatedSprite.sprite);
            position = animatedSprite.position;
            toRender = animatedSprite.toRender;
        }

        public static Animation newAnimation(string[] framesPaths, bool toRender = true, Vector2f position = new Vector2f(), int frameToRender = 0, bool paused = false)
        {
            Texture[] frames = new Texture[framesPaths.Length];

            for (int i = 0; i < framesPaths.Length; i++)
            {
                FileStream stream = new FileStream(framesPaths[i], FileMode.Open);

                frames[i] = new Texture(stream);

                stream.Close();
            }

            Animation animatedSprite = new Animation(frames, position, frameToRender, paused, toRender);
            return animatedSprite;
        }

        public override void TryRender(Camera camera)
        {
            sprite.Texture = frames[frameToRender];

            base.TryRender(camera);

            bool isLastFrame = frameToRender == frames.Length - 1;

            if (isLastFrame)
                toRender = false;

            if (!paused && !isLastFrame)
                frameToRender++;
        }

        public void Start()
        {
            frameToRender = 0;
            toRender = true;
            paused = false;
        }
    }
}
