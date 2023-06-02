using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agario.GameObjects.BlobControllers
{
    class AIController : BlobController
    {
        public AIController(Blob blob) : base(blob)
        {
            this.blob = blob;
        }

        public override void ControlBlob()
        {
            
        }
    }
}
