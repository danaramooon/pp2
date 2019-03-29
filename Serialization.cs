using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadEx
{
        class Program
        {
            static Star star;
            static int cur = 0;
            class Star
            {
                public List<Point> points;

                public Star()
                {
                    points = new List<Point>();
                }

                public void AddPoint(Point p)
                {
                    points.Add(p);
                }

                public void Draw()
                {
                    foreach (Point p in points)
                    {
                        Console.SetCursorPosition(p.x, p.y);
                        Console.Write("*");
                    }
                }
            }
           static void Main(string[] args)
           {
                star = new Star();

                for (int x = 11; x < 14; x++)
                {
                    for (int y = 10; y < 13; y++)
                    {
                        Point p = new Point(x, y);
                        star.AddPoint(p);
                    }
                }


            Thread thread = new Thread(move);
            thread.Start();

            while (true)
            {
                if(cur == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if(cur == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if(cur == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }

    
        }
            static void move()
            {
                while (true)
                {
                    star.Draw();
                    cur += 1;
                    if (cur > 3)
                        cur = 0;
                    Thread.Sleep(1000);
                }
            }
        }
    }
