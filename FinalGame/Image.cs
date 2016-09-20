using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleRender
{
    /// <summary>
    /// Class the encapsulates the image structure
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Set the color on the console 
        /// </summary>
        /// <param name="prevColor">the old color beeing painted</param>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="isForeground">if its meant to change foreground or background color</param>
        public void SetPixel(ref ConsoleColor prevColor,int x,int y, bool isForeground)
        {
            if (image[x, y] != prevColor)
            {
                //read/save the color from that pixel
                prevColor = image[x, y];

                //set the color
                if (isForeground)
                    Console.ForegroundColor = prevColor;

                else
                    Console.BackgroundColor = prevColor;
            }
        }

        /// <summary>
        /// Image buffer, taken as ConsoleColor matrix
        /// </summary>
        private ConsoleColor[,] image;

        /// <summary>
        /// Palett file from this image
        /// </summary>
        private Palette palette;

        /// <summary>
        /// Draw the image at the selected position
        /// </summary>
        /// <param name="xCoord, yCoord">Coordinates</param>
        public void DrawImage(Coordinate coord)
        {
            //Set the foreground color reference
            ConsoleColor prevForeground = Console.ForegroundColor;

            //Set the background color reference
            ConsoleColor prevBackground = Console.BackgroundColor;

            //for each colum
            for (int y = 0; y < image.GetLength(1); y += 2)
            {
                //set the cursor position to the new place
                Console.SetCursorPosition(coord.x, coord.y + (y / 2));

                //for each line
                for (int x = 0; x < image.GetLength(0); x++)
                {
                    SetPixel(ref prevForeground, x, y, true);
                    SetPixel(ref prevBackground, x, y+1, false);
                    Console.Write("▀");
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path">Image path</param>
        /// <param name="palette">Palette used to decode</param>
        public Image(string path, Palette palette)
        {
            Bitmap bImage = new Bitmap("../../"+path);

            this.palette = palette;
            this.image = new ConsoleColor[bImage.Width, bImage.Height];

            for (int y = 0; y < bImage.Height; y += 2)
            {
                for (int x = 0; x < bImage.Width; x++)
                {
                    this.image[x, y] = palette.GetPallet()[bImage.GetPixel(x, y)];
                    this.image[x, y + 1] = palette.GetPallet()[bImage.GetPixel(x, y + 1)];
                }
            }
            bImage.Dispose();
        }
    }
}
