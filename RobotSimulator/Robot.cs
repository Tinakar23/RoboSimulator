namespace RobotSimulator{

    /// <summary>
    /// Public class for the Robot, which holds all the porperties and methods related to Robot.
    /// </summary>
    public class Robot{
        /// <summary>
        /// The x-axis co-ordinate property.
        /// </summary>
        public int Coordinate_x 
        {
            get; 
            private set;
        
        }
        /// <summary>
        /// The y-axis co-ordinate property.
        /// </summary>
        public int Coordinate_y 
        {
            get;
            private set;
        }

/// <summary>
/// The property for facing direction of robot.
/// </summary>
        public DirectionEnum FacingDirection 
        {
            get; 
            private set;
        }

/// <summary>
/// Boolean porperty to check whether the robot is place or not.
/// </summary>
        public bool IsPlaced 
        {
            get; 
            private set;
        }

/// <summary>
/// Public method to place the robot.
/// </summary>
/// <param name="coordinate_x"> x-axis coordinate.</param>
/// <param name="coordinate_y">y-axis coordinate.</param>
/// <param name="facingDirection">Direction robot faces.</param>
        public void PlaceRobot(int coordinate_x, int coordinate_y, DirectionEnum facingDirection)
        {
            Coordinate_x =coordinate_x;
            Coordinate_y = coordinate_y;
            FacingDirection = facingDirection;
            IsPlaced = true;
        }

/// <summary>
/// Public method to move the robot.
/// </summary>
        public void Move()
        {
            if(!IsPlaced) return;

            switch(FacingDirection)
            {
                case DirectionEnum.NORTH:
                    Coordinate_y++;
                    break;
                
                case DirectionEnum.EAST:
                    Coordinate_x++;
                    break;
                
                case DirectionEnum.SOUTH:
                    Coordinate_y--;
                    break;

                case DirectionEnum.WEST:
                    Coordinate_x--;
                    break;
                
            }
        }

/// <summary>
/// Public method to turn the robot left.
/// </summary>
        public void Left()
        {
            if (!IsPlaced) return;
            FacingDirection = (DirectionEnum)(((int)FacingDirection + 3) % 4); // rotate 90° left
        }

/// <summary>
/// Public method to turn the robot right.
/// </summary>
        public void Right()
        {
            if (!IsPlaced) return;
            FacingDirection = (DirectionEnum)(((int)FacingDirection + 1) % 4); // rotate 90° right
        }

/// <summary>
/// Public method to return the current coordinate and direction of the robot.
/// </summary>
/// <returns></returns>
        public string Report()
        {
            return $"{Coordinate_x},{Coordinate_y},{FacingDirection}";
        }

    } 
}