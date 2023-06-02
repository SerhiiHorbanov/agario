using SFML.Window;

namespace Agario.Input
{
    class KeyBind
    {
        public Keyboard.Key key;
        public bool isPressed = false;

        public KeyBind(Keyboard.Key key)
        {
            this.key = key;
        }

        /*public void SetKey(Keyboard.Key key)
            => this.key = key;
        public void SetIsKeyActive(bool isActive)
            => this.isActive = isActive;*/
    }
}
