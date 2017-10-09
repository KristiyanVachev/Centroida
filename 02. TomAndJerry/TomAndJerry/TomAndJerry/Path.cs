using System.Collections.Generic;
using System.Linq;

namespace TomAndJerry
{
    public class Path
    {
        public Path()
        {
            this.Commands = new List<Command>();
            this.Paint = 0;
            this.Turns = 0;
        }

        public Path(IList<Command> commands, int paint, int turns)
        {
            this.Commands = commands;
            this.Paint = paint;
            this.Turns = turns;
        }

        public IList<Command> Commands { get; set; }

        public int Lenght => this.Commands.Count;

        public int Paint { get; set; }

        public int Turns { get; set; }

        public Path Copy()
        {
            return new Path(this.Commands.ToList(), this.Paint, this.Turns);
        }

        public void Add(int row, int col, char direction, char type)
        {
            var newCommand = new Command(row, col, direction);

            if (this.Lenght > 0 && direction != this.Commands.Last().Direction)
            {
                this.Turns++;
            }

            this.Commands.Add(newCommand);

            if (type == 'P')
            {
                this.Paint++;
            }
        }

        public bool Walked(int row, int col)
        {
            return Commands.Any(command => command.Row == row && command.Col == col);
        }
    }
}
