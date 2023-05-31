using Agario.GameObjects;
using Agario.Input;

namespace Agario
{
    static class Player
    {
        public static Blob blob;

        public static void ControlBlob()
        {
            if (InputVars.teleportBind.isKeyActive)
                blob.RandomTeleport();

            blob.Go(InputVars.playerBlobMove);
        }
    }
}
