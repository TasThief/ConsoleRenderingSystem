namespace ConsoleRender
{
    /// <summary>
    /// Simply Coordinate system, 
    /// </summary>
    public struct Coordinate
    {
        public int x;
        public int y;

        /// <summary>
        /// Shorthand for 0,0 coordinate
        /// </summary>
        public static Coordinate zero;

        /// <summary>
        /// Creates a new coordinate
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coodinate</param>
        /// <returns>the new coordinate</returns>
        public static Coordinate NewCoordinate(int x, int y)
        {
            Coordinate newCoordinate;
            newCoordinate.x = x;
            newCoordinate.y = y;
            return newCoordinate;
        }
    }
}
