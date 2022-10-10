using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace SerialisationProject
{
    class MySerialisationExercice
    {
        [JsonProperty] string name = null;
        [JsonProperty] string firstName = null;
        [JsonProperty] int? age = null;
        [JsonProperty] int? height = null;
        [JsonProperty] int? weight = null;
        bool shouldExit = false;

        public void Start()
        {
            AskStringQuestion("What's your name ?", ref name);
            AskStringQuestion("What's your first name ?", ref firstName);
            AskIntQuestion("How old are you ?", ref age);
            AskIntQuestion("How tall are you ?", ref height);
            AskIntQuestion("What is your weight ?", ref weight);
            string path = Path.Combine(Environment.CurrentDirectory, "save.json");
            if (!shouldExit && File.Exists(path))
            {
                File.Delete(path);
            }
        }

        void AskIntQuestion(string question, ref int? variable)
        {
            if (shouldExit) return;
            if (variable.HasValue)
            {
                Console.WriteLine(variable);
            }
            else
            {
                Console.WriteLine(question);
                string input = Program.ReadInput(this);
                if (!shouldExit && isDigit(input))
                {
                    variable = int.Parse(input);
                    Console.WriteLine(variable);
                }
            }
        }

        public void End()
        {
            shouldExit = true;
        }

        void AskStringQuestion(string question, ref string variable)
        {
            if (shouldExit) return;
            if (!string.IsNullOrEmpty(variable))
            {
                Console.WriteLine(variable);
            }
            else
            {
                Console.WriteLine(question);
                string input = Program.ReadInput(this);
                if (!shouldExit)
                {
                    variable = input;
                    Console.WriteLine(variable);
                }
            }
        }

        

        bool isDigit(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
