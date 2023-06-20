using SFML.System;
using SFML.Graphics;
using Agario.Enums;

namespace Agario.GameObjects.Render
{
    class Animation : AgarioSprite
    {
        Texture[] frames;

        public float frameToRender = 0;
        public bool paused = false;
        public ActionAfterAnimationEnd actionAfterAnimationEnd = ActionAfterAnimationEnd.StopRenderingAnimation;
        public bool isReverse = false;
        public float animationPlaySpeed = 1;

        public bool isLastFrame 
            => frameToRender == frames.Length - 1;

        public Animation(Texture[] frames, Vector2f position, int frameToRender = 0, bool paused = false, bool toRender = true, bool isReverse = false)
        {
            this.frames = frames;
            this.frameToRender = frameToRender;
            this.paused = paused;
            this.position = position;
            this.sprite = new Sprite(frames[frameToRender]);
            this.toRender = toRender;
            this.isReverse = isReverse;
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

        public static Animation newAnimation(string[] framesPaths, bool toRender = true, Vector2f position = new Vector2f(), float frameToRender = 0, bool paused = false)
        {
            Texture[] frames = new Texture[framesPaths.Length];

            for (int i = 0; i < framesPaths.Length; i++)
            {
                FileStream stream = new FileStream(framesPaths[i], FileMode.Open);

                frames[i] = new Texture(stream);

                stream.Close();
            }

            Animation animatedSprite = new Animation(frames, position, (int)frameToRender, paused, toRender);
            return animatedSprite;
        }

        public override void TryRender(Camera camera)
        {
            if (frameToRender < frames.Length && frameToRender >= 0)
                sprite.Texture = frames[(int)frameToRender];

            base.TryRender(camera);

            if (isLastFrame)
            {
                switch (actionAfterAnimationEnd)
                {
                    case ActionAfterAnimationEnd.StopRenderingAnimation:
                        toRender = false;
                        break;

                    case ActionAfterAnimationEnd.PlayInReverse:
                        isReverse = !isReverse;
                        break;

                    case ActionAfterAnimationEnd.RestartAnimation:
                        frameToRender = 0;
                        break;
                }

            }

            if (paused)
                return;

            frameToRender += isReverse? 1 : -1;
        }

        public void Start()
        {
            frameToRender = 0;
            toRender = true;
            paused = false;
        }
    }
}
