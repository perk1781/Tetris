using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            //Square s = new Square(5, 3, '*');
            //s.Draw();
            Stick s = new Stick(3, 2, '*');
            s.Draw();

            Thread.Sleep(500);
            s.Hide();
            s.Move(Direction.LEFT);
            s.Draw();

            Thread.Sleep(500);
            s.Hide();
            s.Move(Direction.RIGHT);
            s.Draw();

            Thread.Sleep(500);
            s.Hide();
            s.Move(Direction.DOWN);
            s.Draw();
            //Point p1 = new Point(2, 3, '*');
            //p1.Draw();

            //Point p2 = new Point()
            //{
            //    x = 4,
            //    y = 5,
            //    c = '#'

            //};
          
            //p2.Draw();

            Console.ReadLine();


        }
    }
}
