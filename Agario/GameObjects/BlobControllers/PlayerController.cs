using Agario.GameObjects;
using Agario.Input;

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

        public override void ControlBlob()
        {
            if (input.IsKeyPressed("teleport"))
                blob.RandomTeleport();

            blob.Go(input.GetVector("move"));
        }
    }
}
