using Agario.GameObjects.Render;
using Agario.GameObjects.Interfaces;

namespace Agario.GameObjects
{
    class AnimatedObject : GameObject, IRenderable
    {
        public Camera camera;
        protected Animation animation;

        public AnimatedObject(Animation animation, Camera camera)
        {
            this.animation = animation;
            this.camera = camera;
        }

        public void Render()
        {
            animation.TryRender(camera);
        }
    }
}
