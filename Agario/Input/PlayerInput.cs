using SFML.Window;
using SFML.System;

namespace Agario.Input
{
    class PlayerInput
    {
        private Dictionary<string, KeyBind> inputKeys;

        private Dictionary<string, Vector2f> inputVectors;

        public PlayerInput(Dictionary<string, KeyBind> inputKeyBinds, Dictionary<string, Vector2f> inputVectors)
        {
            this.inputKeys = inputKeyBinds;
            this.inputVectors = inputVectors;
        }

        public Vector2f GetVector(string vectorName)
            => inputVectors[vectorName];

        public KeyBind GetKeyBind(string keyBindName)
            => inputKeys[keyBindName];

        public Keyboard.Key GetKey(string keyBindName)
            => inputKeys[keyBindName].key;

        public bool IsKeyPressed(string keyBindName)
            => inputKeys[keyBindName].isPressed;

        public void SetVector(string vectorName, Vector2f vector)
            => inputVectors[vectorName] = vector;

        public void SetKey(string keyBindName, Keyboard.Key key)
            => inputKeys[keyBindName].key = key;

        public void SetKeyPress(string keyBindName, bool isPressed)
            => inputKeys[keyBindName].isPressed = isPressed;

    }
}
