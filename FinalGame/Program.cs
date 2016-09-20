using System;
using System.Diagnostics;                // for Debug
using System.Drawing;                    // for Color (add reference to  System.Drawing.assembly)
using System.Runtime.InteropServices;    // for StructLayout
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleRender
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer.SetWindow(200, 80);

            Renderer.RenderImage("Splash", "Splash", 39, 20);

            Console.ReadKey(); 
            Console.Clear();

            Renderer.RenderImage("testPallet", "16colormockup", 0, 0);

            Console.ReadKey();
        }
    }
}
