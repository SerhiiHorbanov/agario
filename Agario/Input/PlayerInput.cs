using SFML.Window;
using SFML.System;

namespace Agario.Input
{
    class PlayerInput
    {
        private Dictionary<string, KeyBind> inputKeys;

        private Dictionary<string, Vector2f> inputVectors;

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

        public void AddBinding(string name, Keyboard.Key key)
            => inputKeys.Add(name, new KeyBind(key));

        public void AddVector2(string name)
            => inputVectors.Add(name, new Vector2f());

        public void GetKeyInputInput()
        {
            foreach (KeyBind keyBind in inputKeys.Values)
                keyBind.isPressed = Keyboard.IsKeyPressed(keyBind.key);
        }
    }
}
