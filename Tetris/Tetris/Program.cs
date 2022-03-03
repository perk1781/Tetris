﻿using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure s = null;

            while (true)
            {
                FigureFall(s, generator);
            }


                static void FigureFall(Figure fig, FigureGenerator generator)
            { 
     
                    fig = generator.GetNewFigure();
                    fig.Draw();

                for (int i = 0; i < 15; i++)
                {
                    fig.Hide();
                    fig.Move(Direction.DOWN);
                    fig.Draw();
                    Thread.Sleep(200);
                }
            }
        }
            Console.ReadLine();


        }
    }
}
