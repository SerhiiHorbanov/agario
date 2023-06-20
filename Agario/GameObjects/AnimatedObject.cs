using Agario.GameObjects.Render;
using Agario.GameObjects.Interfaces;

namespace Agario.GameObjects
{
    class AnimatedObject : GameObject, IRenderable, IUpdateable
    {
        public Camera camera;
        private Animation animation;

        public AnimatedObject(Animation animation, Camera camera)
        {
            this.animation = animation;
            this.camera = camera;
        }

        public void Update()
        {
            if (animation.isLastFrame)
                ToDestroy = true;
        }

        public void Render()
        {
            animation.TryRender(camera);
        }
    }
}
