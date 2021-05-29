using System;
using System.Linq;

namespace HepsiCase
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var initialPositionText = Console.ReadLine().Split(" ");
            var roverPosition =
                new PositionalVector(new Point(
                        int.Parse(initialPositionText[0]),
                        int.Parse(initialPositionText[1])),
                    Enum.Parse<Direction>(initialPositionText[2]));
            var commands = Console.ReadLine();
            var fieldManager = new FieldManager(roverPosition, new Point(dimensions[0], dimensions[1]));

            foreach (var command in commands)
            {
                fieldManager.Move(command);
            }
            
            initialPositionText = Console.ReadLine().Split(" ");
            var roverPosition2 =
                new PositionalVector(new Point(
                        int.Parse(initialPositionText[0]),
                        int.Parse(initialPositionText[1])),
                    Enum.Parse<Direction>(initialPositionText[2]));
            commands = Console.ReadLine();
            fieldManager = new FieldManager(roverPosition2, new Point(dimensions[0], dimensions[1]));

            foreach (var command in commands)
            {
                fieldManager.Move(command);
            }
            Console.WriteLine(roverPosition);
            Console.WriteLine(roverPosition2);
        }
    }

   

 
}