using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace ConsoleRender
{
    /// <summary>
    /// Class focused to store a color palett information
    /// </summary>
    public class Palette
    {
        // Dictionary with the colors read from the palett
        Dictionary<Color, ConsoleColor> colors = new Dictionary<Color, ConsoleColor>();

        //create a palett based on a palett file
        public Palette(string filename)
        {
            //initialize the dictionary
            this.colors = new Dictionary<Color, ConsoleColor>();

            //open the file
            FileStream stream = new FileStream("../../"+filename, FileMode.Open, FileAccess.Read, FileShare.Read);

            //read the palett
            using (BinaryReader binaryReader = new BinaryReader(stream))
            {
                //jump 22 bits forward (those are the header of the palett file
                binaryReader.BaseStream.Position = 22;

                //get the size of the palett 
                short size = binaryReader.ReadInt16();

                //for each color
                for (short i = 0; i < 16; i++)
                {
                    //add the new color on the dicitionary and bind it to a new console color enumerations
                    this.colors.Add(Color.FromArgb(binaryReader.ReadByte(), binaryReader.ReadByte(), binaryReader.ReadByte()), (ConsoleColor)i);

                    // skip the flags...
                    binaryReader.ReadByte(); 
                }
            }
            //close the file
            stream.Close();
        }
        public Dictionary<Color, ConsoleColor> GetPallet()
        {
            return colors;
        }
    }


}