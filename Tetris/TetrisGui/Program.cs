using System;
using System.Threading;
using System.Timers;
using Microsoft.SmallBasic.Library;

namespace Tetris
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer timer;
        static private Object _lockObject = new Object();

        static Figure currentFigure;
        static FigureGenerator generator;
        static FigureGenerator factory = new FigureGenerator(Field.Width / 2, 0);
        static bool gameOver = false;

        static void Main(string[] args)
        {
            DrawerProvier.Drawer.InitField();

            generator = new FigureGenerator(Field.Width / 2, 0);
            currentFigure = generator.GetNewFigure();
            SetTimer();

            currentFigure = factory.GetNewFigure();
            currentFigure.Draw();
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
        }

        private static void GraphicsWindow_KeyDown()
        {
            Monitor.Enter(_lockObject);
            var result = HandleKey(currentFigure, GraphicsWindow.LastKey);

            if (GraphicsWindow.LastKey == "Down")
            {
                gameOver = ProcessResult(result, ref currentFigure);
            }

            Monitor.Exit(_lockObject);
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();

                if (currentFigure.IsOnTop())
                {
                    DrawerProvier.Drawer.WriteGameOver();
                    timer.Elapsed -= OnTimedEvent;
                    return true;
                }
                else
                {
                    currentFigure = generator.GetNewFigure();
                    return false;
                }
                
            }
            else
                return false;
        }

        private static Result HandleKey(Figure f, String key)
        {
            switch (key)
            {
                case "Left":
                    return f.TryMove(Direction.LEFT);
                case "Right":
                    return f.TryMove(Direction.RIGHT);
                case "Down":
                    return f.TryMove(Direction.DOWN);
                case "Space":
                    return f.TryRotate();
            }
            return Result.SUCCESS;
        }
        
        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockObject);
        }
    }
}
