## Robot Simulator – C# Console Application  
_A solution to the Champion Data C# Technical Test_

This project simulates a toy robot moving on a 5x5 tabletop using command-based input.  
The robot must obey movement constraints, avoid falling off the table, and report its position accurately.  
The application includes full unit testing using xUnit.

---

## Problem Summary

The robot operates on a 5x5 grid with the origin `(0,0)` at the **south-west** corner.

It accepts the following commands:

| Command | Description |
|--------|-------------|
| `PLACE X,Y,F` | Places the robot at position `(X,Y)` facing direction `F` |
| `MOVE` | Moves the robot 1 unit in the direction it's facing |
| `LEFT` / `RIGHT` | Rotates the robot 90° without moving |
| `REPORT` | Outputs the current position and direction |

### Rules:
- The first valid command **must** be `PLACE`.
- Any movement that causes the robot to fall off the table is ignored.
- Invalid or unknown commands are ignored.
- Directions include: `NORTH`, `SOUTH`, `EAST`, `WEST`.

---

## Tech Stack

- **.NET 8**
- **C# Console Application**
- **xUnit Test Framework**
- **VS Code / CLI Compatible**

---

## Project Structure

```
RobotSimulator/
│
├── RobotSimulator/                  # Main application
│   ├── Program.cs                   # Entry point
│   ├── Robot.cs                     # Robot state + movement rules
│   ├── Table.cs                     # Table boundaries (5x5)
|   ├── CommandProcessor.cs          # Command parsing and execution logic
│   ├── RobotSimulator.csproj
│   └── utilities/
│       ├── commands.txt             # Sample input commands
│       └── DirectionEnum.cs         # Direction enum
│
├── RobotSimulator.Tests/            # Test project
│   ├── RobotTest.cs                 # Unit tests (valid/invalid moves, placement, report)
│   └── RobotSimulator.Tests.csproj
│
└── RobotSimulator.sln               # Solution file
```

---

## How to Run the Application

1. Open terminal in the project directory:

```bash
cd RobotSimulator/RobotSimulator
dotnet run
```

2. The program reads commands from:

```
utilities/commands.txt
```

###  To run with a custom command file:

```bash
dotnet run -- ../path/to/mycommands.txt
```

---

##  Running Unit Tests

From solution root:

```bash
cd RobotSimulator.Tests
dotnet test
```

Expected output:

```
Passed! - Failed: 0 , Passed: X , Skipped: 0
```

---

## Example Input (commands.txt)

```
PLACE 0,0,NORTH
MOVE
RIGHT
MOVE
REPORT
```

### Output:

```
1,1,EAST
```

---

##  How It Works (Overview)

- The command processor parses each line and applies the correct action.
- `TryParse` is used to prevent invalid inputs from causing exceptions.
- All invalid commands or unsafe moves are ignored safely.
- The Robot uses an enum-based direction system for clean rotation logic.
- Dependency injection is applied within the object relationships (Robot + Table → CommandProcessor).

---

## Author

**Tinakar Rajagopal**  
GitHub: https://github.com/Tinakar23

---

## Ready for Review

This repository contains:
- Clean source code  
- A working simulation  
- Comprehensive unit tests  
- A professional project structure  
- README with clear instructions  

Suitable for submission to **Champion Data** as part of the technical assessment.
