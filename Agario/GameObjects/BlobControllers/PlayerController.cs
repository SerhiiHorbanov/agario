using Agario.GameObjects;
using Agario.Input;
using SFML.Window;
using SFML.System;

namespace Agario.GameObjects.BlobControllers
{
    class PlayerController : BlobController
    {
        public PlayerInput input;

        public PlayerController(Blob blob, PlayerInput input) : base(blob)
        {
            this.blob = blob;
            this.input = input;
        }

        public void CheckMoveInput()
        {
            input.SetVector("move", (Vector2f)(Mouse.GetPosition(AgarioGame.window) - (Vector2i)(AgarioGame.window.Size / 2)));
        }

        public override void ControlBlob()
        {
            if (input.IsKeyPressed("teleport"))
                blob.RandomTeleport();

            blob.Go(input.GetVector("move"));
        }
    }
}
