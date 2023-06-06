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
    }
}
