using System;
namespace RobotSimulator{

    /// <summary>
    /// Class to process the commands given to Robot.
    /// </summary>
    public class CommandProcessor
    {
        /// <summary>
        /// Readonly private field of tyoe Robot.
        /// </summary>
        private readonly Robot _robot;

        /// <summary>
        /// Readonly private field of tyoe Table.
        /// </summary>
        private readonly Table _table;

/// <summary>
/// constructor where robot and table class are injeccted.
/// </summary>
/// <param name="robot"> Robot class instance as parameter.</param>
/// <param name="table"> Table class instance as parameter.</param>
        public CommandProcessor(Robot robot, Table table)
        {
            _robot = robot;
            _table = table;
        }

/// <summary>
/// Public method to execute the commands given to robot.
/// </summary>
/// <param name="rawCommand">The raw command given to robot.</param>
/// <returns>The report of robot's position.</returns>
        public string? ExecuteCommand(string? rawCommand)
        {
            ///Checks whether the command is null or empty string.
            if(string.IsNullOrWhiteSpace(rawCommand))
                return null;
            
            ///Converting the command to uppercase to avoid case mismatch.
            var upperCaseCommand = rawCommand.Trim().ToUpperInvariant();

            if(upperCaseCommand.StartsWith("PLACE"))
            {
                ///Call to method that handles the placing of robot.
                HandlePlace(upperCaseCommand);
                return null;
            }

            if(!_robot.IsPlaced)
                return null;
            
            ///Switch case to do other valid commands after placing the robot.
            switch(upperCaseCommand)
            {
                case "MOVE":
                    TryMove();
                    break;
                case "LEFT":
                    _robot.Left();
                    break;

                case "RIGHT":
                    _robot.Right();
                    break;

                case "REPORT":
                    return _robot.Report();

                default:
                    // Unknown command: ignore
                    break;
            }
            return null;
        }

        /// <summary>
        /// Private method which handles the placement of the robot in the table.
        /// </summary>
        /// <param name="placeCommand">The place command  along with co-ordinated and direction as parameter.</param>
        private void HandlePlace(string placeCommand)
        {

///getting the arguments from the command other than the 'PLACE' word.
            var arguments = placeCommand.Substring("PLACE".Length).Trim();
            var parts = arguments.Split(',');  /// splitting the arguments to get the co-ordinates and direction.

            if (parts.Length != 3)
                return;

/// Parsing the 1st part and storing in an out variable if parsing is success or else return nothing,
            if (!int.TryParse(parts[0], out int x)) return;
            
/// Parsing the 2nd part and storing in an out variable if parsing is success or else return nothing,
            if (!int.TryParse(parts[1], out int y)) return;
            
/// Parsing the 3rd part and storing in an out variable if parsing is success or else return nothing,
            if (!Enum.TryParse<DirectionEnum>(parts[2], true, out var direction)) return;

///Calling the validation method to check whether the coordinates are valid or not.
            if (_table.IsValidPosition(x, y))
            {
                /// once success calling the method to place the robot in table.
                _robot.PlaceRobot(x, y, direction);
            }
        }

        /// <summary>
        /// Private method to check whether the move is valid.
        /// </summary>
        private void TryMove()
        {
            int new_coordinate_x = _robot.Coordinate_x;
            int new_coordinate_y = _robot.Coordinate_y;

///Switch case to move robot based on the direction it is facing.
            switch (_robot.FacingDirection)
            {
                case DirectionEnum.NORTH:
                    new_coordinate_y++;
                    break;
                case DirectionEnum.EAST:
                    new_coordinate_x++;
                    break;
                case DirectionEnum.SOUTH:
                    new_coordinate_y--;
                    break;
                case DirectionEnum.WEST:
                    new_coordinate_x--;
                    break;
            }

/// if the new coordinates is valid then the move method is called to move the robot.
            if (_table.IsValidPosition(new_coordinate_x, new_coordinate_y))
            {
                _robot.Move(); 
            }
        }
    }
}