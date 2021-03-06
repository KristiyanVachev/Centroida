﻿namespace TomAndJerry
{
    public class Command
    {
        public Command(int row, int col, char direction)
        {
            this.Row = row;
            this.Col = col;
            this.Direction = direction;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public char Direction { get; set; }

        public bool IsPaint { get; set; }
    }
}
