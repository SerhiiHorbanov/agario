using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agario.GameObjects.BlobControllers
{
    abstract class BlobController
    {
        public Blob blob;
        public BlobController(Blob blob)
        {
            this.blob = blob;
        }

        public abstract void ControlBlob();
    }
}
