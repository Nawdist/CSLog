using System;
using System.Text;
namespace CSLog
{
    public enum LoadingState
    {
        Success,
        Error,
        Warning,
        Info,
    };
    public class LoadingBar
    {

        private readonly char[] chars = { ' ', '█' };
        private readonly char[] spinner = { '|', '/', '-', '\\' };
        private StringBuilder bar;
        private readonly int length = 25;
        private int[] position = new int[2];
        private int k = 0;
        private bool started = false;
        private int currentLevel;

        public void Start()
        {
            //change console encoding to utf-16
            Console.OutputEncoding = Encoding.Unicode;
            started = true;
            position[0] = Console.CursorLeft;
            position[1] = Console.CursorTop;
        }

        public void Update(int level)
        {
            currentLevel = level;
            if (!started) throw new Exception("Cannot call Update() before Start()");
            Console.SetCursorPosition(position[0], position[1]);

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


            if (k >= 3) k = 0;
            else k++;
            Console.Write($" {spinner[k]} {bar.ToString()} {level}%");
        }
        public void Update()
        {
            Console.SetCursorPosition(position[0], position[1]);
            if (k >= 3) k = 0;
            else k++;
            Console.Write($" {spinner[k]} {bar.ToString()} {currentLevel}%");
        }

        public void Success(string message)
        {
            Console.SetCursorPosition(position[0], position[1]);
            started = false;
            Console.WriteLine("✓ ".Green() + message);
        }

        public void End(string message, LoadingState state)
        {
            Console.SetCursorPosition(position[0], position[1]);
            Clear();
            started = false;
            switch (state)
            {
                case LoadingState.Success:
                    Console.WriteLine(("✓ " + message).Green());
                    break;
                case LoadingState.Error:
                    Console.WriteLine(("✗ " + message).Red());
                    break;
                case LoadingState.Warning:
                    Console.WriteLine(("⚠ " + message).Yellow());
                    break;
                case LoadingState.Info:
                    Console.WriteLine(("ⓘ " + message).Cyan());
                    break;
            }
        }

        public void End(string message)
        {
            Console.SetCursorPosition(position[0], position[1]);
            Clear();
            started = false;
            Console.WriteLine(message);
        }

        public void End()
        {
            End("");
        }
        private void Clear()
        {
            started = false;
            Console.SetCursorPosition(position[0], position[1]);
            Console.Write(new string(' ', Console.WindowWidth));
        }

    }
}
public class Logger
{
    public void Info(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write("[INFO ⓘ]");
        Console.ResetColor();
        Console.WriteLine(" " + message);
    }
    public void Warning(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.Write("[WARNING ⚠]");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" " + message);
        Console.ResetColor();
    }

    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("[ERROR ✗]");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" " + message);
        Console.ResetColor();
    }

    public void Success(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Write("[SUCCESS ✓]");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" " + message);
        Console.ResetColor();
    }

    public void Debug(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.Write("[DEBUG]");
        Console.ResetColor();
        Console.WriteLine(" " + message);
    }

}
public static class Chalker
{
    public static string Red(this string message)
    {
        return $"\u001b[31m{message}\u001b[0m";
    }
    public static string Green(this string message)
    {
        return $"\u001b[32m{message}\u001b[0m";
    }
    public static string Yellow(this string message)
    {
        return $"\u001b[33m{message}\u001b[0m";
    }
    public static string Blue(this string message)
    {
        return $"\u001b[34m{message}\u001b[0m";
    }
    public static string Magenta(this string message)
    {
        return $"\u001b[35m{message}\u001b[0m";
    }
    public static string Cyan(this string message)
    {
        return $"\u001b[36m{message}\u001b[0m";
    }
    public static string White(this string message)
    {
        return $"\u001b[37m{message}\u001b[0m";
    }
    public static string Black(this string message)
    {
        return $"\u001b[30m{message}\u001b[0m";
    }
    public static string Bold(this string message)
    {
        return $"\u001b[1m{message}\u001b[0m";
    }
    public static string Underline(this string message)
    {
        return $"\u001b[4m{message}\u001b[0m";
    }
    public static string Invert(this string message)
    {
        return $"\u001b[7m{message}\u001b[0m";
    }
    public static string Blink(this string message)
    {
        return $"\u001b[5m{message}\u001b[0m";
    }
    public static string Hide(this string message)
    {
        return $"\u001b[8m{message}\u001b[0m";
    }
    public static string Strike(this string message)
    {
        return $"\u001b[9m{message}\u001b[0m";
    }
    public static string Reset(this string message)

    {
        return $"\u001b[0m{message}\u001b[0m";
    }

    public static string Italic(this string message)
    {
        return $"\u001b[3m{message}\u001b[0m";
    }

    public static string BgRed(this string message)
    {
        return $"\u001b[41m{message}\u001b[0m";
    }
    public static string BgGreen(this string message)
    {
        return $"\u001b[42m{message}\u001b[0m";
    }
    public static string BgYellow(this string message)
    {
        return $"\u001b[43m{message}\u001b[0m";
    }
    public static string BgBlue(this string message)
    {
        return $"\u001b[44m{message}\u001b[0m";
    }
    public static string BgMagenta(this string message)
    {
        return $"\u001b[45m{message}\u001b[0m";
    }
    public static string BgCyan(this string message)
    {
        return $"\u001b[46m{message}\u001b[0m";
    }
    public static string BgWhite(this string message)
    {
        return $"\u001b[47m{message}\u001b[0m";
    }
    public static string BgBlack(this string message)
    {
        return $"\u001b[40m{message}\u001b[0m";
    }
}