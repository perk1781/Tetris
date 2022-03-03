﻿using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);

            Field.Width = 20;

            FigureGenerator generator = new FigureGenerator(10, 0, '*');
            Figure currentFigure = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                   var key = Console.ReadKey();
                   HandleKey(currentFigure, key);
                }
            }

        Console.ReadLine();
        }

        private static void HandleKey(Figure currentFigure, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentFigure.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    currentFigure.TryMove(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    currentFigure.TryMove(Direction.DOWN);
                    break;
                case ConsoleKey.Spacebar:
                    currentFigure.TryRotate();
                    break;
            }
        }
    }
}
