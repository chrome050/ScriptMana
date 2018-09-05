using System;
using System.Collections.Generic;
using ScriptMana.Helper;
using ScriptMana.Interpreters;

namespace ScriptMana
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new Interpreter.Interpreter();

            Console.WriteLine("Welcome to Script Mana");
            Console.WriteLine("-- {0}", OSDetect.Name);

            var param = new Dictionary<string, string>();

            if (interpreter.Call<Batch>("foo", param).Result)
                Console.WriteLine("Batch call was true!");

            Console.ReadLine();
        }
    }
}
