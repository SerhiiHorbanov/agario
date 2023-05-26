using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Agario
{
    internal class Program
    {
        static public RenderWindow window;

        static void Main(string[] args)
        {
            VideoMode videoMode = new VideoMode(500, 500);

            window = new RenderWindow(videoMode, "2D golf");
            while (true)
            {
                Thread.Sleep(1000);
            }

        }
    }
}
