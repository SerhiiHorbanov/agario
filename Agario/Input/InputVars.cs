using SFML.Window;
using SFML.System;

namespace Agario.Input
{
    static class InputVars
    {
        public static float moveMultiplayer = 0.1f;

        public static Vector2f playerBlobMove = new Vector2f(0, 0);

        public static KeyBind teleportBind = new KeyBind(Keyboard.Key.E);
    }
}
