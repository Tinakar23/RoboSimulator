using RobotSimulator;
using Xunit;
namespace RobotSimulator.Tests
{
    /// <summary>
    /// Unit test class to test the robot actions.
    /// </summary>
public class RobotTests
{
    private readonly Robot _robot;
    private readonly Table _table;
    private readonly CommandProcessor _cp;

/// <summary>
/// Constructor which the instacnes for all test cases are created.
/// </summary>
    public RobotTests()
    {
        _robot = new Robot();
        _table = new Table(5, 5);
        _cp = new CommandProcessor(_robot, _table);
    }
    
    
    /// <summary>
    /// Unit test method to test success case of placing the robot in table with valid coordinates.
    /// </summary>
    [Fact]
    public void PlaceRobot_ValidPosition_Success()
    {
        ////ACT
            _cp.ExecuteCommand("PLACE 1,2,NORTH");

        ////ASSERT
            Assert.True(_robot.IsPlaced);
            Assert.Equal(1, _robot.Coordinate_x);
            Assert.Equal(2, _robot.Coordinate_y);
            Assert.Equal(DirectionEnum.NORTH, _robot.FacingDirection);
    }

/// <summary>
    /// Unit test method to test success case of igloring the placing of robot in table with invalid coordinates.
/// </summary>
    [Fact]
    public void PlaceRobot_InvalidPosition_Ignore_Success()
    {
       
        //// ACT
        _cp.ExecuteCommand("PLACE 10,2,NORTH");

        ////Arrange
        Assert.False(_robot.IsPlaced);
    }

/// <summary>
    /// Unit test method to test success case of moving  the robot in table with valid coordinates.
/// </summary>
    [Fact]
    public void MoveRobot_ValidPosition_Success()
    {
        ////ACT
            _cp.ExecuteCommand("PLACE 1,2,NORTH");
            _cp.ExecuteCommand("MOVE");

        ////ASSERT
            Assert.Equal(1, _robot.Coordinate_x);
            Assert.Equal(3, _robot.Coordinate_y);
            Assert.Equal(DirectionEnum.NORTH, _robot.FacingDirection);

    }

/// <summary>
    /// Unit test method to test success case of no move of robot in edge of table with valid coordinates.
/// </summary>
    [Fact]
    public void MoveRobot_AtEdge_NoMove_Success()
    {

        ////ACT
            _cp.ExecuteCommand("PLACE 4,0,EAST");
            _cp.ExecuteCommand("MOVE");
        ////ASSERT
            Assert.Equal(4, _robot.Coordinate_x);
            Assert.Equal(0, _robot.Coordinate_y);
    }

/// <summary>
    /// Unit test method to test success case of returning the report.
/// </summary>
    [Fact]
    public void Report_Return_Success()
    {
        
        ////ACT
            _cp.ExecuteCommand("PLACE 2,3,WEST");
            var result = _cp.ExecuteCommand("REPORT");
        ////ASSERT
            Assert.Equal("2,3,WEST", result);

    }

/// <summary>
    /// Unit test method to test success case of placing the robot in table with valid coordinates.
/// </summary>
    [Fact]
    public void MixedCommands_ValidAndInvalid_Success()
    {
        // Arrange
        var commands = new[]
                {
                    "MOVE",              
                    "LEFT",              
                    "REPORT",            
                    "PLACE 0,0,NORTH",   
                    "MOVE",              
                    "PLACE 10,5,EAST",   
                    "PLACE 0,4,NORTH",   
                    "MOVE",              
                    "RIGHT",             
                    "MOVE",              
                    "JUMP",              
                    "REPORT"             
                };
                string? lastOutput = null;

        // Act
        foreach (var command in commands)
                {
                    var output = _cp.ExecuteCommand(command);
                    if (!string.IsNullOrWhiteSpace(output))
                    {
                        lastOutput = output;
                    }
                }

        // Assert
        Assert.Equal("1,4,EAST", lastOutput);
    }

    
}
}