using System;
using System.IO;
namespace RobotSimulator
{
    public class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">the parametr for the main method.</param>
        public static void Main(string[] args)
        {
            ///Object creation of robot, table and commandprocessor classes.
            var robot = new Robot();
            var table = new Table(5,5);
            var processor = new CommandProcessor(robot, table);

///getting the input file name from arguments or else assigning the default input file.
            string inputFile = args.Length >0? args[0] : "utilities/commands.txt";

///Checkes whether the input file exist or not and displays a message if not found.
            if(!File.Exists(inputFile))
            {
                Console.WriteLine($"input file  '{inputFile}' not found.");
                return;
            } 

/// reads the line from file and call the 'ExecuteCommand' method from the instance of command processor class.
            foreach(var line in File.ReadLines(inputFile))
            {
                var output = processor.ExecuteCommand(line);
                if(!string.IsNullOrEmpty(output)){
                    Console.WriteLine(output);/// Finally printing the output in console.
                }
            }
        }
    }
}