using Agario.GameObjects.Interfaces;
using Agario.GameObjects.Render;

namespace Agario.GameObjects
{
    class TeleportationEffect : AnimatedObject, IUpdateable
    {
        public const string animationPath = "Textures/Random teleport animation frames";

        public static readonly Animation teleportationAnimation =
            Animation.newAnimation(
                new string[5]
                {
                    animationPath + "/frame0.png",
                    animationPath + "/frame1.png",
                    animationPath + "/frame2.png",
                    animationPath + "/frame3.png",
                    animationPath + "/frame4.png"
                }, 0.5f);

        public TeleportationEffect(Animation animation, Camera camera) : base(animation, camera)
        {
            this.animation = animation;
            this.camera = camera;
        }

        public void Update()
        {
            if (animation.isLastFrame)
                toDestroy = true;
        }
    }
}
