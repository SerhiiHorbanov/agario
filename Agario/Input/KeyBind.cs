using SFML.Window;

namespace Agario.Input
{
    struct KeyBind
    {
        public Keyboard.Key key;
        public bool isKeyActive = false;

        public KeyBind(Keyboard.Key key)
        {
            this.key = key;
        }
    }
}
