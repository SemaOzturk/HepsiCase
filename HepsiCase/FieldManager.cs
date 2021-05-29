using System;

namespace HepsiCase
{
    public class FieldManager
    {
        private readonly PositionalVector _roverPosition;
        private readonly Point _field;
        private readonly DirectionCommandState _directionCommandState = new DirectionCommandState();

        public FieldManager(PositionalVector roverPosition, Point field)
        {
            _roverPosition = roverPosition;
            _field = field;
        }


        public void Move(char moveCommand)
        {
            var command = Enum.Parse<DirectionCommandState.Command>(moveCommand.ToString().ToUpper());
            switch (command)
            {
                case DirectionCommandState.Command.R:
                case DirectionCommandState.Command.L:
                    var newDirection = _directionCommandState.Rotate(_roverPosition.Direction, command);
                    _roverPosition.SetDirection(newDirection);
                    goto default;
                case DirectionCommandState.Command.M:
                    _roverPosition.Move();
                    goto default;
                default:
                    CheckBoundary();
                    break;
            }
        }

        private void CheckBoundary()
        {
            _roverPosition.Point.CheckXBoundary(_field.X);
            _roverPosition.Point.CheckYBoundary(_field.Y);
        }
    }
}