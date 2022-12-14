using System;
using System.IO;
using Newtonsoft.Json;


namespace SerialisationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MySerialisationExercice exercice = null;
            string path = Path.Combine(Environment.CurrentDirectory, "save.json");
            if (File.Exists(path))
            {
                exercice = Load();
            }
            else
            {
                exercice = new MySerialisationExercice();
            }

            exercice.Start();
        }

        static public void Save(MySerialisationExercice exercice)
        {
            string data = JsonConvert.SerializeObject(exercice, Formatting.Indented);
            string path = Path.Combine(Environment.CurrentDirectory, "save.json");
            File.WriteAllText(path, data);
        }

        static public MySerialisationExercice Load()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "save.json");
            string data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<MySerialisationExercice>(data);
        }

        static public string ReadInput(MySerialisationExercice exercice)
        {
            bool stopReading = false;
            string result = "";
            while (!stopReading)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.Enter:
                        return result;
                    case ConsoleKey.Backspace:
                        if(result.Length > 0)
                        {
                            result = result.Remove(result.Length - 1);
                            OverwriteCurrentConsoleLine(result);
                        }
                        break;
                    case ConsoleKey.Escape:
                        Save(exercice);
                        stopReading = true;
                        exercice.End();
                        break;
                    default:
                        result += info.KeyChar;
                        OverwriteCurrentConsoleLine(result);
                        break;
                }
            }

            return result;
        }

        public static void OverwriteCurrentConsoleLine(string s)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(s, Console.BufferWidth);
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void ClearLastLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}
