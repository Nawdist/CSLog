using System;
using System.Threading;
using System.Text;
namespace NawLog
{

    public class Loader
    {

        private readonly char[] chars = { ' ', '█' };
        private readonly char[] spinner = { '|', '/', '-', '\\' };
        private StringBuilder bar;
        private readonly int length = 25;
        private int[] position = new int[2];
        private int k = 0;
        private bool started = false;
        private int currentLevel;
        public Loader()
        {

        }

        public void Start()
        {
            
            started = true;
            position[0] = Console.CursorLeft;
            position[1] = Console.CursorTop;
        }

        public void Update(int level)
        {
            currentLevel = level;
            if (!started) throw new Exception("Cannot call Update() before Start()");
            Console.SetCursorPosition(position[0], position[1]);

            if(k <= 3) k = 0;
            else k++; 

            bar = new StringBuilder("[");
            for (int j = 1; j < 25; j++)
            {
                bar.Append(chars[0]);
            };

            bar.Append("]");
            for (int i = 1; i < Math.Round(((float)level * length) / 100); i++)
            {
                bar[i] = chars[1];
            }

            Console.Write($" {spinner[k]} {bar.ToString()} {level}%");
        }
        public void Update()
        {
            Console.Write($" {spinner[k]} {bar.ToString()} {currentLevel}%");
        }

    }


    public class Log
    {
        struct Vec2
        {
            public Vec2(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
            public int x, y;
        }
        public static void Info(string message)
        {

        }
    }
}