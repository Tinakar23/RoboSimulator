namespace RobotSimulator{
    /// <summary>
    /// Public class holds properties and methods related to Table.
    /// </summary>
    public class Table
    {
        public int Width
        {
            get;
        }
        public int Height
        {
            get;
        }

/// <summary>
/// Constructor of the table class.
/// </summary>
/// <param name="width">The width of the table.</param>
/// <param name="height">The height of the table.</param>
        public Table(int width, int height)
        {
            Width = width;
            Height = height;
        }

/// <summary>
/// The method to check whethe the given position is valid to place the robot.
/// </summary>
/// <param name="coordinate_x">x-axis co-ordinate.</param>
/// <param name="coordinate_y">y-axis coordinate.</param>
/// <returns></returns>
        public bool IsValidPosition(int coordinate_x, int coordinate_y)
        {
            return coordinate_x>= 0 && coordinate_x < Width && coordinate_y >=0 && coordinate_y < Height;
        }
    }
}