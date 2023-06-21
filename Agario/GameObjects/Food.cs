using System;
using SFML.System;
using SFML.Graphics;
using Agario.GameObjects.Render;

namespace Agario.GameObjects
{
    class Food : AnimatedObject
    {
        public Vector2f Position
            => animation.position;

        public new const float radius = 10;

        public static readonly Animation standartAnimation = Animation.newAnimation(new string[4]
        {
            animationPath + "/frame1.png",
            animationPath + "/frame2.png",
            animationPath + "/frame3.png",
            animationPath + "/frame4.png"
        });

        public const string animationPath = "Textures/Eating animation frames";
        public Food(Animation animation, Vector2f position, Camera camera) : base(animation, camera)
        {
            this.animation = animation;
            this.animation.position = position;
            Console.WriteLine(position);
            this.camera = camera;
            animation.actionAfterAnimationEnd = Enums.ActionAfterAnimationEnd.PlayInReverse;
        }
    }
}
